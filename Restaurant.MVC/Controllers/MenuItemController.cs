using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.MenuItem;

namespace Restaurant.MVC.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _menuItemService;
        private readonly ICategoryService _categoryService;

        public MenuItemController(IMenuItemService menuItemService, ICategoryService categoryService)
        {
            _menuItemService = menuItemService;
            _categoryService = categoryService;
        }
        // GET: MenuItemController
        public async Task<ActionResult> Index()
        {
            var menuItems = await _menuItemService.GetMenuItems();
            return View(menuItems);
        }

        // GET: MenuItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var menutItem = await _menuItemService.GetMenuItemDetails(id);
            return View(menutItem);
        }

        // GET: MenuItemController/Create
        public async Task<ActionResult> Create()
        {
            //Get category to fill the combobox
            ViewBag.categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        // POST: MenuItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMenuItemVM menuItem)
        {
            //Get category to fill the combobox
            ViewBag.categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            try
            {
                var response = await _menuItemService.CreateMenuItem(menuItem);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(menuItem);

        }

        // GET: MenuItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //Get category to fill the combobox
            ViewBag.categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            var menutItem = await _menuItemService.GetMenuItemDetails(id);
            return View(menutItem);
        }

        // POST: MenuItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MenuItemVM menuItem)
        {
            //Get category to fill the combobox
            ViewBag.categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            try
            {
                var response = await _menuItemService.UpdateMenuItem(id, menuItem);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(menuItem);
        }
        // POST: MenuItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _menuItemService.DeleteMenuItem(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
