using InventoryManagementApp.Data;
using InventoryManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InventoryManagementApp.Controllers
{
    public class HomeController(ApplicationDbContext db) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var inventories = await db.Inventories.ToListAsync();
            return View(inventories);
        }
    }
}
