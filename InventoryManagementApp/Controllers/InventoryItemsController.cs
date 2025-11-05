using Microsoft.AspNetCore.Mvc;
using InventoryManagementApp.Data;
using InventoryManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagementApp.Controllers
{
    [Authorize]
    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            item.CreatedAt = DateTime.UtcNow;

            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();

            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .ThenInclude(x => x.CreatedBy)
                .FirstOrDefaultAsync(i => i.Id == item.InventoryId);

            if (inventory == null)
                return NotFound();

            return PartialView("~/Views/InventoryItems/_ItemsTable.cshtml", inventory.Items);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.InventoryItems
                .Include(x => x.CreatedBy)
                .Include(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            return View(item);
        }
    }
}
