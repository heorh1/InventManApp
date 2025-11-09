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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(new InventoryCreateViewModel());
        }

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
            if (user == null)
                return Unauthorized();

            var inventory = new Inventory
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                IsPublic = model.IsPublic,
                Creator = user,

                // Single-line text fields
                CustomString1State = model.CustomString1State,
                CustomString1Name = model.CustomString1Name,
                CustomString1Description = model.CustomString1Description,
                CustomString2State = model.CustomString2State,
                CustomString2Name = model.CustomString2Name,
                CustomString2Description = model.CustomString2Description,
                CustomString3State = model.CustomString3State,
                CustomString3Name = model.CustomString3Name,
                CustomString3Description = model.CustomString3Description,

                // Numeric fields
                CustomInt1State = model.CustomInt1State,
                CustomInt1Name = model.CustomInt1Name,
                CustomInt1Description = model.CustomInt1Description,
                CustomInt2State = model.CustomInt2State,
                CustomInt2Name = model.CustomInt2Name,
                CustomInt2Description = model.CustomInt2Description,
                CustomInt3State = model.CustomInt3State,
                CustomInt3Name = model.CustomInt3Name,
                CustomInt3Description = model.CustomInt3Description,

                // Boolean fields
                CustomBool1State = model.CustomBool1State,
                CustomBool1Name = model.CustomBool1Name,
                CustomBool1Description = model.CustomBool1Description,
                CustomBool2State = model.CustomBool2State,
                CustomBool2Name = model.CustomBool2Name,
                CustomBool2Description = model.CustomBool2Description,
                CustomBool3State = model.CustomBool3State,
                CustomBool3Name = model.CustomBool3Name,
                CustomBool3Description = model.CustomBool3Description,

                // Multi-line fields
                CustomMultiline1State = model.CustomMultiline1State,
                CustomMultiline1Name = model.CustomMultiline1Name,
                CustomMultiline1Description = model.CustomMultiline1Description,
                CustomMultiline2State = model.CustomMultiline2State,
                CustomMultiline2Name = model.CustomMultiline2Name,
                CustomMultiline2Description = model.CustomMultiline2Description,
                CustomMultiline3State = model.CustomMultiline3State,
                CustomMultiline3Name = model.CustomMultiline3Name,
                CustomMultiline3Description = model.CustomMultiline3Description,

                // Links (Document/Image)
                CustomLink1State = model.CustomLink1State,
                CustomLink1Name = model.CustomLink1Name,
                CustomLink1Description = model.CustomLink1Description,
                CustomLink2State = model.CustomLink2State,
                CustomLink2Name = model.CustomLink2Name,
                CustomLink2Description = model.CustomLink2Description,
                CustomLink3State = model.CustomLink3State,
                CustomLink3Name = model.CustomLink3Name,
                CustomLink3Description = model.CustomLink3Description
            };

            try
            {
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error while creating: {ex.Message}";
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View(model);
            }

            TempData["SuccessMessage"] = "Inventory created successfully!";
            TempData["CreatedInventoryId"] = inventory.Id;

            return RedirectToAction("Create");
        }

        // Новый метод для добавления элементов в Inventory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(InventoryCreateViewModel model)
        {
            if (model.InventoryId == null || model.InventoryId == 0)
            {
                TempData["ErrorMessage"] = "Cannot add item: Inventory ID is missing.";
                return RedirectToAction("Create");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == model.InventoryId);

            if (inventory == null)
            {
                TempData["ErrorMessage"] = "Inventory not found.";
                return RedirectToAction("Create");
            }

            var newItem = new InventoryItem
            {
                InventoryId = inventory.Id,
                CreatedById = user.Id,

                CustomString1Value = inventory.CustomString1State ? model.CustomString1Value : null,
                CustomString2Value = inventory.CustomString2State ? model.CustomString2Value : null,
                CustomString3Value = inventory.CustomString3State ? model.CustomString3Value : null,

                CustomInt1Value = inventory.CustomInt1State ? model.CustomInt1Value : null,
                CustomInt2Value = inventory.CustomInt2State ? model.CustomInt2Value : null,
                CustomInt3Value = inventory.CustomInt3State ? model.CustomInt3Value : null,

                CustomBool1Value = inventory.CustomBool1State ? model.CustomBool1Value : null,
                CustomBool2Value = inventory.CustomBool2State ? model.CustomBool2Value : null,
                CustomBool3Value = inventory.CustomBool3State ? model.CustomBool3Value : null,

                CustomMultiline1Value = inventory.CustomMultiline1State ? model.CustomMultiline1Value : null,
                CustomMultiline2Value = inventory.CustomMultiline2State ? model.CustomMultiline2Value : null,
                CustomMultiline3Value = inventory.CustomMultiline3State ? model.CustomMultiline3Value : null,

                CustomLink1Value = inventory.CustomLink1State ? model.CustomLink1Value : null,
                CustomLink2Value = inventory.CustomLink2State ? model.CustomLink2Value : null,
                CustomLink3Value = inventory.CustomLink3State ? model.CustomLink3Value : null
            };

            _context.InventoryItems.Add(newItem);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Item added successfully!";
            return RedirectToAction("Create", new { id = inventory.Id });
        }
    }
}
