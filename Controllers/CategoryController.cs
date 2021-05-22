using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodProject.Models;
using FoodProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FoodProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category, string returnUrl)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    if (_context.Categories.Any(c => c.Name == category.Name))
                    {
                        TempData["SameNameError"] = "Category with same name already exists";
                        return RedirectToAction("Add");
                    }
                    _context.Categories.Add(category);
                    _context.SaveChanges();

                    return Redirect(returnUrl);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return RedirectToAction("Add");
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int categoryId, string returnUrl)
        {
            if (categoryId == 0)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = _context.Categories
                        .Include(c => c.FoodItems)
                        .FirstOrDefault(c => c.CategoryId == categoryId);

                    foreach (var item in category.FoodItems)
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                    _context.Entry(category).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Redirect(returnUrl);
                }
            }
            return Redirect(returnUrl);
        }

        public IActionResult Edit(int categoryId, string returnUrl)
        {
            if (categoryId == 0)
            {
                return BadRequest();
            }
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            if (returnUrl != null)
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category, string returnUrl)
        {
            if (category == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                if (_context.Categories.Any(c => c.Name == category.Name))
                {
                    TempData["SameNameError"] = "Category with same name already exists";
                    return View(category);
                }
                try
                {
                    _context.Entry(category).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Category", "Home");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Redirect(returnUrl);
                }
            }
            return View(category);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AddItem(int categoryId, string returnUrl)
        {
            FoodItem foodItem = new FoodItem();
            if (categoryId != 0)
            {
                foodItem.CategoryId = categoryId;
                foodItem.Category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            }
            if (returnUrl != null)
            {
                ViewBag.ReturnUrl = Url.Action("Category", new { categoryId = categoryId });
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(foodItem);
        }

        [HttpPost]
        public IActionResult AddItem(FoodItem foodItem, string returnUrl)
        {
            if (foodItem == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                foodItem.Category = _context.Categories.Find(foodItem.CategoryId);
                if (_context.FoodItems.Any(f => f.Name == foodItem.Name))
                {
                    TempData["SameNameError"] = "Item with same name already exists";
                    ViewBag.ReturnUrl = returnUrl;
                    return Redirect(Url.Action("AddItem", new
                    {
                        categoryId = foodItem.CategoryId,
                        returnUrl = returnUrl
                    }));
                }
                try
                {
                    _context.FoodItems.Add(foodItem);
                    _context.SaveChanges();
                    if(returnUrl == "/Home/All") return Redirect(returnUrl);
                    else return RedirectToAction("Category", "Home", new { categoryId = foodItem.CategoryId }, "selectedFoodTable");
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return RedirectToAction("AddItem");
                }
            }
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult RemoveItem(string foodItemId, string returnUrl)
        {
            if (foodItemId == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    FoodItem foodItem = _context.FoodItems
                        .FirstOrDefault(c => c.FoodItemId == foodItemId);

                    _context.Entry(foodItem).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Redirect(returnUrl);
                }
            }
            return Redirect(returnUrl);
        }

        public IActionResult EditItem(string foodItemId, string returnUrl)
        {
            if (foodItemId == null)
            {
                return BadRequest();
            }
            var foodItem = _context.FoodItems.FirstOrDefault(c => c.FoodItemId == foodItemId);

            if (foodItem == null)
            {
                return NotFound();
            }

            if (returnUrl != null)
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(foodItem);
        }

        [HttpPost]
        public ActionResult EditItem(FoodItem foodItem, string returnUrl)
        {
            if (foodItem == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                foodItem.Category = _context.Categories.FirstOrDefault(c => c.CategoryId == foodItem.CategoryId);
                if (_context.FoodItems.Contains(foodItem))
                {
                    TempData["SameNameError"] = foodItem.Name + " already exists in category " + foodItem.Category.Name;
                    ViewBag.Categories = _context.Categories.ToList();
                    return View(foodItem);
                }
                try
                {
                    _context.Entry(foodItem).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Redirect(returnUrl);

                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Redirect(returnUrl);
                }
            }
            return View(foodItem);
        }
    }
}