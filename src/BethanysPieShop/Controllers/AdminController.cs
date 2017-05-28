using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class AdminController : Controller
    {
        IPieRepository _pieRepository ;

        private readonly AppDbContext _context;

        public AdminController(IPieRepository pieRepository, AppDbContext appDbContext)
        {
            _context = appDbContext;
            _pieRepository= pieRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(string pieName, string pieCategory)
        {
            // 1) Kolla att pieName och pieCategory sätts
            var Pie1 = new Pie()
            {
                Name = pieName,
                Category = new Category { CategoryName = pieCategory}

            };
            if (ModelState.IsValid)
            {
                _pieRepository.AddPie(Pie1);
                  _context.SaveChanges();
                return RedirectToAction("Index");
            }


            //AddPie(pieName);

            // 2) Skapa en Pie utifrån pieName och pieCategory

            // 3) Anropa repo't för att lägga till pajen


            return Ok("topp dollar!");

            //using (var _context = new AppDbContext())
            //{
            //if (ModelState.IsValid)
            //{
            //    _context.Add(pie);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(pie);
            //}
        }
    }
}
