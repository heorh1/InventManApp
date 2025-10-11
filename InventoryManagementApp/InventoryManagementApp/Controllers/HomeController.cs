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
            var items = await db.InventoryItems.ToListAsync();
            return View(items);
        }
    }
}
