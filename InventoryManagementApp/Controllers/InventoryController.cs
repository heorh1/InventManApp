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
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public InventoryController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var inventories = await _db.Inventories
                .Include(i => i.Category)
                .Include(i => i.Creator)
                .Where(i => i.IsPublic || (userId != null && i.CreatorId == userId))
                .ToListAsync();

            return View(inventories);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var inv = await _db.Inventories
                .Include(i => i.Category)
                .Include(i => i.Creator)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inv == null) return NotFound();

            if (!inv.IsPublic && inv.CreatorId != _userManager.GetUserId(User))
                return Forbid();

            return View(inv);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new InventoryCreateViewModel();

            ViewBag.Categories = await _db.Categories.ToListAsync();

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _db.Categories.ToListAsync();
                return View(vm);
            }

            var userId = _userManager.GetUserId(User);

            var entity = new Inventory
            {
                Title = vm.Title,
                Description = vm.Description,
                CategoryId = vm.CategoryId,
                IsPublic = vm.IsPublic,
                CreatorId = userId,

                // Single-line text fields
                CustomString1State = vm.CustomString1State,
                CustomString1Name = vm.CustomString1Name,
                CustomString1Description = vm.CustomString1Description,
                CustomString2State = vm.CustomString2State,
                CustomString2Name = vm.CustomString2Name,
                CustomString2Description = vm.CustomString2Description,
                CustomString3State = vm.CustomString3State,
                CustomString3Name = vm.CustomString3Name,
                CustomString3Description = vm.CustomString3Description,

                // Numeric fields
                CustomInt1State = vm.CustomInt1State,
                CustomInt1Name = vm.CustomInt1Name,
                CustomInt1Description = vm.CustomInt1Description,
                CustomInt2State = vm.CustomInt2State,
                CustomInt2Name = vm.CustomInt2Name,
                CustomInt2Description = vm.CustomInt2Description,
                CustomInt3State = vm.CustomInt3State,
                CustomInt3Name = vm.CustomInt3Name,
                CustomInt3Description = vm.CustomInt3Description,

                // Boolean fields
                CustomBool1State = vm.CustomBool1State,
                CustomBool1Name = vm.CustomBool1Name,
                CustomBool1Description = vm.CustomBool1Description,
                CustomBool2State = vm.CustomBool2State,
                CustomBool2Name = vm.CustomBool2Name,
                CustomBool2Description = vm.CustomBool2Description,
                CustomBool3State = vm.CustomBool3State,
                CustomBool3Name = vm.CustomBool3Name,
                CustomBool3Description = vm.CustomBool3Description,

                // Multi-line text fields
                CustomMultiline1State = vm.CustomMultiline1State,
                CustomMultiline1Name = vm.CustomMultiline1Name,
                CustomMultiline1Description = vm.CustomMultiline1Description,
                CustomMultiline2State = vm.CustomMultiline2State,
                CustomMultiline2Name = vm.CustomMultiline2Name,
                CustomMultiline2Description = vm.CustomMultiline2Description,
                CustomMultiline3State = vm.CustomMultiline3State,
                CustomMultiline3Name = vm.CustomMultiline3Name,
                CustomMultiline3Description = vm.CustomMultiline3Description,

                // Image/Link fields
                CustomLink1State = vm.CustomLink1State,
                CustomLink1Name = vm.CustomLink1Name,
                CustomLink1Description = vm.CustomLink1Description,
                CustomLink2State = vm.CustomLink2State,
                CustomLink2Name = vm.CustomLink2Name,
                CustomLink2Description = vm.CustomLink2Description,
                CustomLink3State = vm.CustomLink3State,
                CustomLink3Name = vm.CustomLink3Name,
                CustomLink3Description = vm.CustomLink3Description
            };

            _db.Inventories.Add(entity);
            await _db.SaveChangesAsync();

            ViewBag.SuccessMessage = "✅ Inventory created successfully";
            ModelState.Clear();

            // Снова подгружаем категории для формы
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(new InventoryCreateViewModel());
        }


        public async Task<IActionResult> Edit(int id)
        {
            var inv = await _db.Inventories.FindAsync(id);
            if (inv == null) return NotFound();

            if (inv.CreatorId != _userManager.GetUserId(User))
                return Forbid();

            var vm = new InventoryEditViewModel
            {
                Id = inv.Id,
                Title = inv.Title,
                Description = inv.Description,
                CategoryId = inv.CategoryId,
                IsPublic = inv.IsPublic,

                // Single-line
                CustomString1State = inv.CustomString1State,
                CustomString1Name = inv.CustomString1Name,
                CustomString1Description = inv.CustomString1Description,

                CustomString2State = inv.CustomString2State,
                CustomString2Name = inv.CustomString2Name,
                CustomString2Description = inv.CustomString2Description,

                CustomString3State = inv.CustomString3State,
                CustomString3Name = inv.CustomString3Name,
                CustomString3Description = inv.CustomString3Description,

                // Numeric
                CustomInt1State = inv.CustomInt1State,
                CustomInt1Name = inv.CustomInt1Name,
                CustomInt1Description = inv.CustomInt1Description,

                CustomInt2State = inv.CustomInt2State,
                CustomInt2Name = inv.CustomInt2Name,
                CustomInt2Description = inv.CustomInt2Description,

                CustomInt3State = inv.CustomInt3State,
                CustomInt3Name = inv.CustomInt3Name,
                CustomInt3Description = inv.CustomInt3Description,

                // Boolean
                CustomBool1State = inv.CustomBool1State,
                CustomBool1Name = inv.CustomBool1Name,
                CustomBool1Description = inv.CustomBool1Description,

                CustomBool2State = inv.CustomBool2State,
                CustomBool2Name = inv.CustomBool2Name,
                CustomBool2Description = inv.CustomBool2Description,

                CustomBool3State = inv.CustomBool3State,
                CustomBool3Name = inv.CustomBool3Name,
                CustomBool3Description = inv.CustomBool3Description,

                // Multi-line
                CustomMultiline1State = inv.CustomMultiline1State,
                CustomMultiline1Name = inv.CustomMultiline1Name,
                CustomMultiline1Description = inv.CustomMultiline1Description,

                CustomMultiline2State = inv.CustomMultiline2State,
                CustomMultiline2Name = inv.CustomMultiline2Name,
                CustomMultiline2Description = inv.CustomMultiline2Description,

                CustomMultiline3State = inv.CustomMultiline3State,
                CustomMultiline3Name = inv.CustomMultiline3Name,
                CustomMultiline3Description = inv.CustomMultiline3Description,

                // Links
                CustomLink1State = inv.CustomLink1State,
                CustomLink1Name = inv.CustomLink1Name,
                CustomLink1Description = inv.CustomLink1Description,

                CustomLink2State = inv.CustomLink2State,
                CustomLink2Name = inv.CustomLink2Name,
                CustomLink2Description = inv.CustomLink2Description,

                CustomLink3State = inv.CustomLink3State,
                CustomLink3Name = inv.CustomLink3Name,
                CustomLink3Description = inv.CustomLink3Description
            };

            ViewBag.Categories = await _db.Categories
                .Select(c => new { c.Id, c.Name })
                .ToListAsync();

            return View(vm);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InventoryEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _db.Categories
                    .Select(c => new { c.Id, c.Name })
                    .ToListAsync();
                return View(vm);
            }

            var inv = await _db.Inventories.FindAsync(id);
            if (inv == null) return NotFound();

            if (inv.CreatorId != _userManager.GetUserId(User))
                return Forbid();

            inv.Title = vm.Title;
            inv.Description = vm.Description;
            inv.CategoryId = vm.CategoryId;
            inv.IsPublic = vm.IsPublic;

            // Single-line
            inv.CustomString1State = vm.CustomString1State;
            inv.CustomString1Name = vm.CustomString1Name;
            inv.CustomString1Description = vm.CustomString1Description;

            inv.CustomString2State = vm.CustomString2State;
            inv.CustomString2Name = vm.CustomString2Name;
            inv.CustomString2Description = vm.CustomString2Description;

            inv.CustomString3State = vm.CustomString3State;
            inv.CustomString3Name = vm.CustomString3Name;
            inv.CustomString3Description = vm.CustomString3Description;

            // Numeric
            inv.CustomInt1State = vm.CustomInt1State;
            inv.CustomInt1Name = vm.CustomInt1Name;
            inv.CustomInt1Description = vm.CustomInt1Description;

            inv.CustomInt2State = vm.CustomInt2State;
            inv.CustomInt2Name = vm.CustomInt2Name;
            inv.CustomInt2Description = vm.CustomInt2Description;

            inv.CustomInt3State = vm.CustomInt3State;
            inv.CustomInt3Name = vm.CustomInt3Name;
            inv.CustomInt3Description = vm.CustomInt3Description;

            // Boolean
            inv.CustomBool1State = vm.CustomBool1State;
            inv.CustomBool1Name = vm.CustomBool1Name;
            inv.CustomBool1Description = vm.CustomBool1Description;

            inv.CustomBool2State = vm.CustomBool2State;
            inv.CustomBool2Name = vm.CustomBool2Name;
            inv.CustomBool2Description = vm.CustomBool2Description;

            inv.CustomBool3State = vm.CustomBool3State;
            inv.CustomBool3Name = vm.CustomBool3Name;
            inv.CustomBool3Description = vm.CustomBool3Description;

            // Multi-line
            inv.CustomMultiline1State = vm.CustomMultiline1State;
            inv.CustomMultiline1Name = vm.CustomMultiline1Name;
            inv.CustomMultiline1Description = vm.CustomMultiline1Description;

            inv.CustomMultiline2State = vm.CustomMultiline2State;
            inv.CustomMultiline2Name = vm.CustomMultiline2Name;
            inv.CustomMultiline2Description = vm.CustomMultiline2Description;

            inv.CustomMultiline3State = vm.CustomMultiline3State;
            inv.CustomMultiline3Name = vm.CustomMultiline3Name;
            inv.CustomMultiline3Description = vm.CustomMultiline3Description;

            // Links
            inv.CustomLink1State = vm.CustomLink1State;
            inv.CustomLink1Name = vm.CustomLink1Name;
            inv.CustomLink1Description = vm.CustomLink1Description;

            inv.CustomLink2State = vm.CustomLink2State;
            inv.CustomLink2Name = vm.CustomLink2Name;
            inv.CustomLink2Description = vm.CustomLink2Description;

            inv.CustomLink3State = vm.CustomLink3State;
            inv.CustomLink3Name = vm.CustomLink3Name;
            inv.CustomLink3Description = vm.CustomLink3Description;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var inv = await _db.Inventories.FindAsync(id);
            if (inv == null) return NotFound();

            if (inv.CreatorId != _userManager.GetUserId(User))
                return Forbid();

            return View(inv);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inv = await _db.Inventories.FindAsync(id);
            if (inv == null) return NotFound();

            if (inv.CreatorId != _userManager.GetUserId(User))
                return Forbid();

            _db.Inventories.Remove(inv);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
