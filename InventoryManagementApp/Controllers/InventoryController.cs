using InventoryManagementApp.Data;
using InventoryManagementApp.Models;
using InventoryManagementApp.ViewModels.InventoryViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApp.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InventoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Create Inventory
        [HttpGet]
        public async Task<IActionResult> Create(int? id, string? activeTab = null)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            InventoryCreateViewModel model;

            if (id.HasValue)
            {
                var inventory = await _context.Inventories
                    .Include(i => i.Items)
                    .FirstOrDefaultAsync(i => i.Id == id.Value);

                if (inventory == null) return NotFound();

                model = new InventoryCreateViewModel
                {
                    InventoryId = inventory.Id,
                    Title = inventory.Title,
                    Description = inventory.Description,
                    CategoryId = inventory.CategoryId,
                    IsPublic = inventory.IsPublic,
                    Items = inventory.Items.ToList(),

                    CustomString1Name = inventory.CustomString1Name,
                    CustomString2Name = inventory.CustomString2Name,
                    CustomString3Name = inventory.CustomString3Name,
                    CustomInt1Name = inventory.CustomInt1Name,
                    CustomInt2Name = inventory.CustomInt2Name,
                    CustomInt3Name = inventory.CustomInt3Name,
                    CustomBool1Name = inventory.CustomBool1Name,
                    CustomBool2Name = inventory.CustomBool2Name,
                    CustomBool3Name = inventory.CustomBool3Name,
                    CustomMultiline1Name = inventory.CustomMultiline1Name,
                    CustomMultiline2Name = inventory.CustomMultiline2Name,
                    CustomMultiline3Name = inventory.CustomMultiline3Name,
                    CustomLink1Name = inventory.CustomLink1Name,
                    CustomLink2Name = inventory.CustomLink2Name,
                    CustomLink3Name = inventory.CustomLink3Name
                };

                if (activeTab == "items")
                {
                    ViewBag.LoadAddItemForm = true;
                }

            }
            else
            {
                model = new InventoryCreateViewModel();
            }

            ViewBag.ActiveTab = activeTab ?? "settings";

            return View(model);
        }

        // POST: Create Inventory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var inventory = new Inventory
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                IsPublic = model.IsPublic,
                Creator = user,

                CustomString1Name = model.CustomString1Name,
                CustomString2Name = model.CustomString2Name,
                CustomString3Name = model.CustomString3Name,
                CustomInt1Name = model.CustomInt1Name,
                CustomInt2Name = model.CustomInt2Name,
                CustomInt3Name = model.CustomInt3Name,
                CustomBool1Name = model.CustomBool1Name,
                CustomBool2Name = model.CustomBool2Name,
                CustomBool3Name = model.CustomBool3Name,
                CustomMultiline1Name = model.CustomMultiline1Name,
                CustomMultiline2Name = model.CustomMultiline2Name,
                CustomMultiline3Name = model.CustomMultiline3Name,
                CustomLink1Name = model.CustomLink1Name,
                CustomLink2Name = model.CustomLink2Name,
                CustomLink3Name = model.CustomLink3Name
            };

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Inventory created successfully!";
            return RedirectToAction("Create", new { id = inventory.Id, activeTab = "items" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAddItemForm(int inventoryId)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryId);
            if (inventory == null)
                return NotFound();

            var model = new AddItemViewModel
            {
                InventoryId = inventoryId,

                CustomString1Name = inventory.CustomString1Name,
                CustomString2Name = inventory.CustomString2Name,
                CustomString3Name = inventory.CustomString3Name,

                CustomInt1Name = inventory.CustomInt1Name,
                CustomInt2Name = inventory.CustomInt2Name,
                CustomInt3Name = inventory.CustomInt3Name,

                CustomBool1Name = inventory.CustomBool1Name,
                CustomBool2Name = inventory.CustomBool2Name,
                CustomBool3Name = inventory.CustomBool3Name,

                CustomMultiline1Name = inventory.CustomMultiline1Name,
                CustomMultiline2Name = inventory.CustomMultiline2Name,
                CustomMultiline3Name = inventory.CustomMultiline3Name,

                CustomLink1Name = inventory.CustomLink1Name,
                CustomLink2Name = inventory.CustomLink2Name,
                CustomLink3Name = inventory.CustomLink3Name
            };

            return PartialView("_AddItemFormPartial", model);
        }


        // POST: Add Item to Inventory (AJAX)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(AddItemViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == model.InventoryId);

            if (inventory == null) return NotFound();

            var item = new InventoryItem
            {
                InventoryId = model.InventoryId,
                CustomString1Value = model.CustomString1Value,
                CustomString2Value = model.CustomString2Value,
                CustomString3Value = model.CustomString3Value,
                CustomInt1Value = model.CustomInt1Value,
                CustomInt2Value = model.CustomInt2Value,
                CustomInt3Value = model.CustomInt3Value,
                CustomBool1Value = model.CustomBool1Value,
                CustomBool2Value = model.CustomBool2Value,
                CustomBool3Value = model.CustomBool3Value,
                CustomMultiline1Value = model.CustomMultiline1Value,
                CustomMultiline2Value = model.CustomMultiline2Value,
                CustomMultiline3Value = model.CustomMultiline3Value,
                CustomLink1Value = model.CustomLink1Value,
                CustomLink2Value = model.CustomLink2Value,
                CustomLink3Value = model.CustomLink3Value
            };

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

                inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == model.InventoryId);

            return PartialView("_ItemListPartial", inventory.Items.ToList());
        }
    }
}
