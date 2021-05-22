using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using FoodProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FoodProject.Controllers
{
    
    public class OrderController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.User).Include(o => o.Items).OrderBy(o => o.OrderDate).ToList();
            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeliverAsync(string id, string returnUrl)
        {
            string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

            Order order = await _context.Orders
                .Include(ord => ord.User)
                .Include(ord => ord.Items)
                .Where(ord => ord.OrderId == id)
                .SingleOrDefaultAsync();

            order.Status = "Delivered";
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToLocalAction(returnUrl);
        }

        public async Task<ActionResult> Details()
        {
            string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;
            
            var userOrders = await _context.Orders
                .Include(order => order.Items)
                .Where(order => order.UserId == userId).OrderBy(o => o.OrderDate).ToListAsync();

            if (userOrders == null || userOrders.Count() < 1)
            {
                return View();
            }
            
            return View(userOrders);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id, string returnUrl)
        {
            string userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

            Order order = _context.Orders
                .Include(ord => ord.User)
                .Include(ord => ord.Items)
                .FirstOrDefault(ord => ord.OrderId == id);

            List<CartItem> items = order.Items.ToList();

            items.ForEach(itm => 
            {
                itm.OrderId = null;
                _context.Entry(itm).State = EntityState.Modified;
            });

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToLocalAction(returnUrl);
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

            return RedirectToAction("Details");
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
