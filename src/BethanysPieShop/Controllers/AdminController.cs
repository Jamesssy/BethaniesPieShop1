using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using BethanysPieShop.ViewModels;

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



        public IActionResult CreateDropDown()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy(c => c.CategoryName), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateDropDown([Bind("Name,CategoryId")] AddPieDropDownListViewModel pieViewModel)
        {
            if (ModelState.IsValid)
            {
                var pie = new Pie();
                pie.Name = pieViewModel.Name.Trim();
                
                pie.CategoryId = pieViewModel.CategoryId;
                

                _context.Pies.Add(pie);
                _context.SaveChanges();

                return Ok($"Pie with name: '{pieViewModel.Name.Trim()}' in category: '{pieViewModel.CategoryId}', Where added into the database.");
                //return RedirectToAction("Details", "Pie", pie.PieId);
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy(r => r.CategoryName), "CategoryId", "CategoryName", pieViewModel.CategoryId);

            return View(pieViewModel);
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


        //private IConfigurationRoot _configurationRoot;

        

        //private void LoadSubjects()
        //{

        //    Category subjects = new Category();

        //    using (SqlConnection con = new SqlConnection(_configurationRoot.GetConnectionString("DefaultConnection")))
        //    {

        //        try
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter("SELECT SubjectID, SubjectName FROM Students.dbo.Subjects", con);
        //            adapter.Fill(subjects);

        //            ddlSubject.DataSource = subjects;
        //            ddlSubject.DataTextField = "SubjectNamne";
        //            ddlSubject.DataValueField = "SubjectID";
        //            ddlSubject.DataBind();
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle the error
        //        }

        //    }

        //    // Add the initial item - you can add this even if the options from the
        //    // db were not successfully loaded
        //    ddlSubject.Items.Insert(0, new ListItem("<Select Subject>", "0"));

        //}




    }
}
