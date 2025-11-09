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
    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InventoryItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET
        public async Task<IActionResult> ForInventory(int inventoryId)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == inventoryId);

            if (inventory == null)
                return NotFound();

            var vm = new InventoryItemsViewModel
            {
                InventoryId = inventory.Id,
                InventoryTitle = inventory.Title,
                Inventory = inventory,
                Items = inventory.Items?.ToList() ?? new List<InventoryItem>()
            };

            return PartialView("~/Views/Inventory/CreateTabs/_Items.cshtml", vm);
        }

        // POST: /InventoryItems/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(InventoryItemsViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ForInventory", new { inventoryId = model.InventoryId });

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var inventory = await _context.Inventories.FindAsync(model.InventoryId);
            if (inventory == null)
                return NotFound();

            var item = new InventoryItem
            {
                InventoryId = model.InventoryId,
                CreatedById = user.Id,
                CustomString1Value = model.CustomString1Value,
                CustomInt1Value = model.CustomInt1Value
            };

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Item added successfully!";
            return RedirectToAction("ForInventory", new { inventoryId = model.InventoryId });
        }
    }
}
