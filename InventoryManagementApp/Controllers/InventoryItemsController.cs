using InventoryManagementApp.Data;
using InventoryManagementApp.Models;
using InventoryManagementApp.ViewModels.Inventory;
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

        // GET: InventoryItems/Index/5
        public async Task<IActionResult> Index(int inventoryId)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == inventoryId);

            if (inventory == null)
                return NotFound();

            var model = new InventoryItemsViewModel
            {
                Inventory = inventory,
                Items = inventory.Items?.ToList() ?? new List<InventoryItem>()
            };

            return View(model);
        }

        // POST: InventoryItems/Add
        [HttpPost]
        public async Task<IActionResult> Add(int inventoryId, InventoryItem item)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryId);
            if (inventory == null)
                return NotFound();

            item.InventoryId = inventoryId;
            item.CreatedById = _userManager.GetUserId(User);
            item.CreatedAt = DateTime.UtcNow;

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { inventoryId });
        }
    }
}
