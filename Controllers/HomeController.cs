using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VendingMachine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        
        private MyContext _context;


        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            ViewBag.ShelvesWithCandies = _context.Shelves
                .Include(s => s.ShelvedCandyBars)
                .ToList();

            return View();
        }
        [HttpGet("inventory")]
        public IActionResult ManageInventory()
        {
            ViewBag.Shelves = _context.Shelves
                .Include(i => i.ShelvedCandyBars)
                .ToList();
            return View();
        }

        [HttpGet("inventory/{id}/new")]
        public IActionResult NewCandy(int id)
        {
            ViewBag.ShelfId = id;
            ViewBag.Shelves = _context.Shelves
                .Include(i => i.ShelvedCandyBars)
                .ToList();
            return View();
        }

        [HttpPost("inventory/create")]
        public IActionResult CreateCandy(Candy newCandy)
        {
            _context.Add(newCandy);
            _context.SaveChanges();
            return RedirectToAction("ManageInventory");
        }

        [HttpGet("candy/{id}")]
        public IActionResult BuyCandy(int id)
        {
            // I need to decriment the candy bar qty and create a wrapper
            Candy RetreivedCandy = _context.Candies
                .FirstOrDefault(candy => candy.CandyId == id);
            RetreivedCandy.Qty -= 1;
            RetreivedCandy.UpdatedAt = DateTime.Now;

            Wrapper WrapperExists = _context.Wrappers
                .FirstOrDefault(wrap => wrap.WrapperColor == RetreivedCandy.WrapperColor);

            if(WrapperExists == null)
            {
                _context.SaveChanges();
                string color = RetreivedCandy.WrapperColor;
                
                return RedirectToAction("CreateWrapper", new { color = color});
            }
            WrapperExists.Qty += 1;
            WrapperExists.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("wrapper/{color}")]
        public IActionResult CreateWrapper(string color)
        {
            Wrapper newWrapper = new Wrapper()
            {
                WrapperColor = color,
                Qty = 1
            };
            Console.WriteLine("Made it to create wrapper");
            _context.Add(newWrapper);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("candy/{id}/decrease")]
        public IActionResult DecreaseCandy(int id)
        {
            Console.WriteLine("Made it to decrease candy function");
            Candy UpdateCandy = _context.Candies
                .FirstOrDefault(cand => cand.CandyId == id);

            UpdateCandy.Qty -= 1;
            UpdateCandy.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("ManageInventory");
        }

        [HttpGet("candy/{id}/increase")]
        public IActionResult IncreaseCandy(int id)
        {
            Candy UpdateCandy = _context.Candies
                .FirstOrDefault(cand => cand.CandyId == id);

            UpdateCandy.Qty += 1;
            UpdateCandy.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            
            return RedirectToAction("ManageInventory");
        }

        [HttpGet("report")]
        public IActionResult Report()
        {
            ViewBag.Sour = _context.Shelves
                .FirstOrDefault(s => s.Flavor == "Sour");
            
            ViewBag.CommonWrapper = _context.Wrappers
                .OrderByDescending(gp => gp.Qty)
                .First();
            
            ViewBag.AllShelves = _context.Shelves
                .Include(shelf => shelf.ShelvedCandyBars)
                .ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
