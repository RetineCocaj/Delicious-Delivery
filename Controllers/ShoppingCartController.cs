using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FoodProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FoodProject.Models;

namespace FoodProject.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ActionResult> DetailsAsync()
        {
            var userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            ApplicationUser user = _context.Users
                .Include(u => u.ShoppingCart)
                .Where(u => u.Id == userId)
                .SingleOrDefault();

            bool userHasOrder = _context.Orders
                .Where(order => order.UserId == user.Id).Count() > 0;

            if (userHasOrder)
            {
                ViewBag.HasOrder = true;
            }

            ShoppingCart shoppingCart = user.ShoppingCart;
            if (shoppingCart == null)
            {
                return View();
            }
            shoppingCart.Items = _context.CartItems.Where(c => c.ShoppingCartId == shoppingCart.ShoppingCartId).ToList();

            return View(shoppingCart.Items);
        }


        public async Task<ActionResult> Edit(string cartItemId, string returnUrl)
        {
            if (cartItemId == null)
            {
                return BadRequest();
            }
            var cartItem = await _context.CartItems.Where(c => c.CartItemId == cartItemId).SingleOrDefaultAsync();

            if (cartItem == null)
            {
                return NotFound();
            }

            if (returnUrl != null)
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View(cartItem);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(string cartItemId, string returnUrl, int quantity)
        {

            CartItem cartItem = _context.CartItems.Find(cartItemId);
            ShoppingCart cart = _context.ShoppingCarts.FirstOrDefault(c => c.Items.Any(c => c.CartItemId == cartItemId));
            cart.Sum -= cartItem.TotalAmount;
            cartItem.Quantity = quantity;
            cartItem.TotalAmount = quantity * cartItem.Price;
            cart.Sum += cartItem.TotalAmount;
            if (TryUpdateModelAsync<CartItem>(cartItem).Result && TryUpdateModelAsync<ShoppingCart>(cart).Result)
            {
                _context.Entry(cartItem).State = EntityState.Modified;
                _context.Entry(cart).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToLocalAction(returnUrl);
            }

            return View(cartItem);
        }

        public async Task<ActionResult> Remove(string cartItemId, string returnUrl)
        {
            if (cartItemId == null)
            {
                return BadRequest();
            }


            string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            var cart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(shoppingCart => shoppingCart.UserId == userId);
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item == null || cart == null)
            {
                return NotFound();
            }

            try
            {
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.ErrorMessage = "There was an error item was not successfully removed, please try again...";
                return View("Details", cart.Items.ToList());
            }

            ViewBag.Message = "Item Removed.";

            if (cart.Items == null)
            {
                bool isDeleted = await DeleteShoppingCartAsync(cart);
                if (isDeleted)
                {
                    return RedirectToLocalAction(returnUrl);
                }
            }
            return RedirectToLocalAction(returnUrl);
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CheckoutAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

                ApplicationUser user = _context.Users
                    .Include(usr => usr.ShoppingCart)
                    .Include(usr => usr.ShoppingCart.Items)
                    .Where(usr => usr.Id == userId)
                    .SingleOrDefault();

                ShoppingCart cart = user.ShoppingCart;

                if (cart == null)
                {
                    TempData["Empty Cart"] = "Your Cart is empty.";
                    return RedirectToAction("Checkout");
                }

                order.OrderId = GetNewUid();
                order.TotalAmount = cart.Sum;
                order.UserId = user.Id;
                order.OrderDate = DateTime.UtcNow;

                cart.Items.ToList().ForEach(cartItem =>
                    {
                        cartItem.ShoppingCartId = null;
                        cartItem.OrderId = order.OrderId;
                        _context.Entry(cartItem).State = EntityState.Modified;
                    });

                user.ShoppingCartId = null;
                _context.Entry(user).State = EntityState.Modified;
                _context.Entry(cart).State = EntityState.Deleted;

                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    return View("CheckoutConfirmed");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return RedirectToAction("Checkout");
                }
            }
            return View();
        }

        private async Task<bool> DeleteShoppingCartAsync(ShoppingCart cart)
        {
            var userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            ApplicationUser user = _context.Users
                .Include(u => u.ShoppingCart)
                .Where(u => u.Id == userId)
                .SingleOrDefault();
            user.ShoppingCartId = null;
            user.ShoppingCart = null;
            _context.Entry(cart).State = EntityState.Deleted;
            _context.Entry(user).State = EntityState.Modified;

            int rowsAffected = _context.SaveChanges();

            return rowsAffected > 0;

        }

        private List<FoodItem> GetFoodItems()
        {
            List<FoodItem> foodItems = _context.FoodItems.Include(f => f.Category)
                .Where(f => f.Discriminator == Discriminators.FoodItem)
                .ToList();

            return foodItems;
        }

        private string GetNewUid()
        {
            return Guid.NewGuid().ToString();
        }

        private ActionResult RedirectToLocalAction(string returnUrl)
        {
            if (returnUrl != null)
            {
                if (Url.IsLocalUrl(returnUrl))
                {  
                    return Redirect(returnUrl);
                }
                else
                {
                    ViewBag.ErrorMessage = "The return Url did not originate from our Server";
                    return View("Error");
                }
            }

            return RedirectToAction("All");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
