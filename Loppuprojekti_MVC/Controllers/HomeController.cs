using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loppuprojekti_MVC.Models;
using Loppuprojekti_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Loppuprojekti_MVC.Controllers
{
    public class HomeController : Controller
    {
        //Yritys 2.
        //private readonly MVC_Context _context;

        //public HomeController(MVC_Context context)
        //{
        //    _context = context;
        //}


        public async Task<IActionResult> Index(string searchString)
        {
            //define query
            var ispecies = from s in _context.IndividualSpecies
                           select s;

            //run query against dataset
            //doesn't go to RestUrils yet..
            if (!String.IsNullOrEmpty(searchString))
            {
                ispecies = ispecies.Where(s => s.ScientificName.Contains(searchString));
            }
            return View(await ispecies.ToListAsync());
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

        //POST from search field, forwards parametres to GET
        public ActionResult NSearch(NameSearch scName)
        {
            if (string.IsNullOrEmpty(scName.ScientificName))
            {
                ModelState.AddModelError("", "Please search with a name.");
                return RedirectToAction("Index");
            }
            else
            {
                //viekö hakuehdot mukanaan?
                return RedirectToAction("SingleSpecies","Species");
            }
        }
    }
}
