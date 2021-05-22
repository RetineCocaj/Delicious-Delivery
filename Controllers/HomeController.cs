using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodProject.Models;
using FoodProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Buy(string id, string returnUrl)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                TempData["NotLoggedIn"] = "Please Login/Register to continue the process";
                return Redirect(returnUrl);
            }
            FoodItem foodItem = _context.FoodItems.Find(id);

            if (foodItem == null)
            {
                return NotFound();
            }
            if (returnUrl != null)
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View(foodItem);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmBuyAsync(string foodItemId, string returnUrl, int Quantity)
        {
            FoodItem foodItem = _context.FoodItems.Find(foodItemId);
            if (foodItem.isEnabled == false)
            {
                ViewBag.ErrorMessage = "This item is currently unavailable.";
                return View("All", GetFoodItems());
            }

            if (foodItem != null)
            {
                string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

                var user = _context.Users
                    .Include(u => u.ShoppingCart)
                        .ThenInclude(s => s.Items)
                    .FirstOrDefault( u => u.Id == userId);

                if (user != null && user.ShoppingCart == null)
                {
                    if (CreateAndSaveNewShoppingCart(user) == false)
                    {
                        throw new Exception("There was a problem saving a new Shopping cart in the database.");
                    }
                }

                ShoppingCart cart = user.ShoppingCart;
                return CreateSaveCartItemAndRedirect(foodItem, cart, returnUrl, Quantity);

            }
            else
            {
                ViewBag.ErrorMeesage = "The item was not specified, please click a 'Add to Cart' Button to proceed";
                return View("All", GetFoodItems());
            }


        }
        private ActionResult CreateSaveCartItemAndRedirect(FoodItem foodItem, ShoppingCart cart, string returnUrl, int Quantity)
        {
            if (IsItemInCart(cart, foodItem) == true)
            {
                ViewBag.ErrorMessage = $"Item '{ foodItem.Name}' is already in your Cart";
                return View("All", GetFoodItems());
            }

            CartItem cartItem = new CartItem
            {
                CartItemId = GetNewUid(),
                Name = foodItem.Name,
                Price = foodItem.Price,
                Quantity = Quantity,
                TotalAmount = (foodItem.Price * Quantity),
                ShoppingCartId = cart.ShoppingCartId,
                Discriminator = Discriminators.CartItem
            };

            cart.Sum += cartItem.TotalAmount;
            _context.Entry(cart).State = EntityState.Modified;
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            ViewBag.ReturnUrl = returnUrl;
            return RedirectToLocalAction(returnUrl);
        }

        private bool CreateAndSaveNewShoppingCart(ApplicationUser user)
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                UserId = user.Id,
                ShoppingCartId = GetNewUid(),
                Sum = 0,
                Items = new List<CartItem>()
            };
            user.ShoppingCartId = shoppingCart.ShoppingCartId;

            _context.Entry(user).State = EntityState.Modified;
            _context.ShoppingCarts.Add(shoppingCart);

            int affectedRows = _context.SaveChanges();

            return affectedRows > 0;
        }

        private bool IsItemInCart(ShoppingCart cart, FoodItem foodItem)
        {
            bool isInCart = cart.Items.Where(item => item.Name == foodItem.Name).SingleOrDefault() != null;

            return isInCart;
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


        public async Task<ActionResult> Category(int? categoryId)
        {
            var categories = _context.Categories.Include(c => c.FoodItems);
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.FoodItems = new List<FoodItem>();
            viewModel.Categories = categories.ToList();
            if (categoryId != null)
            {
                ViewBag.CategoryId = categoryId;
                var foods = categories
                    .FirstOrDefault(c => c.CategoryId == categoryId)
                    .FoodItems;

                if (User.Identity.IsAuthenticated == false)
                {
                    viewModel.FoodItems = foods;
                    return View(viewModel);
                }

                Dictionary<string, FoodItem> foodItems = foods.ToDictionary(fList => fList.Name);

                string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

                var user = _context.Users.Find(userId);
                var cart = _context.ShoppingCarts
                    .Include(shoppingCart => shoppingCart.Items)
                    .FirstOrDefault(s => s.UserId == userId);

                if (cart != null)
                {
                    List<CartItem> cartItems = cart.Items.ToList();

                    cartItems.ForEach(cartItem =>
                    {
                        if (foodItems.ContainsKey(cartItem.Name))
                        {
                            var foodItem = foodItems[cartItem.Name];
                            foodItem.isEnabled = false;
                            foodItem.CartItemId = cartItem.CartItemId;
                        }
                    });
                }
                viewModel.FoodItems =  foodItems.Select(f => f.Value).ToList();
            }


            ViewBag.ReturnUrl = Url.Action("Category", "Home");

            return View(viewModel);
        }

        public async Task<ActionResult> All(string message)
        {
            var foods = GetFoodItems();
            if (User.Identity.IsAuthenticated == false)
            {
                return View(foods);
            }

            Dictionary<string, FoodItem> foodItems = foods.ToDictionary(fList => fList.Name);

            string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

            var user = _context.Users.Find(userId);
            var cart = _context.ShoppingCarts
                .Include(shoppingCart => shoppingCart.Items)
                .FirstOrDefault(s => s.UserId == userId);
            if (cart != null)
            {
                List<CartItem> cartItems = cart.Items.ToList();

                cartItems.ForEach(cartItem =>
                {
                    if (foodItems.ContainsKey(cartItem.Name))
                    {
                        var foodItem = foodItems[cartItem.Name];
                        foodItem.isEnabled = false;
                        foodItem.CartItemId = cartItem.CartItemId;
                    }
                });
            }
            foods = foodItems.Select(f => f.Value).ToList();

            if (message != null)
            {
                ViewBag.Message = "Item Removed.";
            }
            return View(foods);
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
