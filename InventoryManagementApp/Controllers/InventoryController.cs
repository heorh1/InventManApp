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
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InventoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // === CREATE ===
        [HttpGet]
        public IActionResult Create()
        {
            return View(new InventoryCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);

            var inventory = new Models.Inventory
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                IsPublic = model.IsPublic,
                Creator = user,

                // поля
                CustomString1State = model.CustomString1State,
                CustomString1Name = model.CustomString1Name,
                CustomString1Description = model.CustomString1Description,

                CustomString2State = model.CustomString2State,
                CustomString2Name = model.CustomString2Name,
                CustomString2Description = model.CustomString2Description,

                CustomString3State = model.CustomString3State,
                CustomString3Name = model.CustomString3Name,
                CustomString3Description = model.CustomString3Description,

                CustomInt1State = model.CustomInt1State,
                CustomInt1Name = model.CustomInt1Name,
                CustomInt1Description = model.CustomInt1Description,

                CustomInt2State = model.CustomInt2State,
                CustomInt2Name = model.CustomInt2Name,
                CustomInt2Description = model.CustomInt2Description,

                CustomInt3State = model.CustomInt3State,
                CustomInt3Name = model.CustomInt3Name,
                CustomInt3Description = model.CustomInt3Description,

                CustomBool1State = model.CustomBool1State,
                CustomBool1Name = model.CustomBool1Name,
                CustomBool1Description = model.CustomBool1Description,

                CustomBool2State = model.CustomBool2State,
                CustomBool2Name = model.CustomBool2Name,
                CustomBool2Description = model.CustomBool2Description,

                CustomBool3State = model.CustomBool3State,
                CustomBool3Name = model.CustomBool3Name,
                CustomBool3Description = model.CustomBool3Description,

                CustomMultiline1State = model.CustomMultiline1State,
                CustomMultiline1Name = model.CustomMultiline1Name,
                CustomMultiline1Description = model.CustomMultiline1Description,

                CustomMultiline2State = model.CustomMultiline2State,
                CustomMultiline2Name = model.CustomMultiline2Name,
                CustomMultiline2Description = model.CustomMultiline2Description,

                CustomMultiline3State = model.CustomMultiline3State,
                CustomMultiline3Name = model.CustomMultiline3Name,
                CustomMultiline3Description = model.CustomMultiline3Description,

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

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            // После создания сразу идем в Edit
            return RedirectToAction("Edit", new { id = inventory.Id });
        }

        // === EDIT ===
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inventory == null)
                return NotFound();

            var model = new InventoryEditViewModel
            {
                Id = inventory.Id,
                Title = inventory.Title,
                Description = inventory.Description,
                CategoryId = inventory.CategoryId,
                IsPublic = inventory.IsPublic,

                CustomString1State = inventory.CustomString1State,
                CustomString1Name = inventory.CustomString1Name,
                CustomString1Description = inventory.CustomString1Description,

                CustomString2State = inventory.CustomString2State,
                CustomString2Name = inventory.CustomString2Name,
                CustomString2Description = inventory.CustomString2Description,

                CustomString3State = inventory.CustomString3State,
                CustomString3Name = inventory.CustomString3Name,
                CustomString3Description = inventory.CustomString3Description,

                CustomInt1State = inventory.CustomInt1State,
                CustomInt1Name = inventory.CustomInt1Name,
                CustomInt1Description = inventory.CustomInt1Description,

                CustomInt2State = inventory.CustomInt2State,
                CustomInt2Name = inventory.CustomInt2Name,
                CustomInt2Description = inventory.CustomInt2Description,

                CustomInt3State = inventory.CustomInt3State,
                CustomInt3Name = inventory.CustomInt3Name,
                CustomInt3Description = inventory.CustomInt3Description,

                CustomBool1State = inventory.CustomBool1State,
                CustomBool1Name = inventory.CustomBool1Name,
                CustomBool1Description = inventory.CustomBool1Description,

                CustomBool2State = inventory.CustomBool2State,
                CustomBool2Name = inventory.CustomBool2Name,
                CustomBool2Description = inventory.CustomBool2Description,

                CustomBool3State = inventory.CustomBool3State,
                CustomBool3Name = inventory.CustomBool3Name,
                CustomBool3Description = inventory.CustomBool3Description,

                CustomMultiline1State = inventory.CustomMultiline1State,
                CustomMultiline1Name = inventory.CustomMultiline1Name,
                CustomMultiline1Description = inventory.CustomMultiline1Description,

                CustomMultiline2State = inventory.CustomMultiline2State,
                CustomMultiline2Name = inventory.CustomMultiline2Name,
                CustomMultiline2Description = inventory.CustomMultiline2Description,

                CustomMultiline3State = inventory.CustomMultiline3State,
                CustomMultiline3Name = inventory.CustomMultiline3Name,
                CustomMultiline3Description = inventory.CustomMultiline3Description,

                CustomLink1State = inventory.CustomLink1State,
                CustomLink1Name = inventory.CustomLink1Name,
                CustomLink1Description = inventory.CustomLink1Description,

                CustomLink2State = inventory.CustomLink2State,
                CustomLink2Name = inventory.CustomLink2Name,
                CustomLink2Description = inventory.CustomLink2Description,

                CustomLink3State = inventory.CustomLink3State,
                CustomLink3Name = inventory.CustomLink3Name,
                CustomLink3Description = inventory.CustomLink3Description
            };

            ViewData["Inventory"] = inventory;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InventoryEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
                return NotFound();

            inventory.Title = model.Title;
            inventory.Description = model.Description;
            inventory.CategoryId = model.CategoryId;
            inventory.IsPublic = model.IsPublic;

            inventory.CustomString1State = model.CustomString1State;
            inventory.CustomString1Name = model.CustomString1Name;
            inventory.CustomString1Description = model.CustomString1Description;

            // (остальные поля — аналогично, опущены для краткости)
            await _context.SaveChangesAsync();

            TempData["Success"] = "Inventory updated successfully!";
            return RedirectToAction("Edit", new { id });
        }
    }
}
