using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loppuprojekti_MVC.Models;

namespace Loppuprojekti_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        //search field
        //POST from search field, forwards parametres to GET in SpeciesController/RestUtil??
        //returns 
        public ActionResult NSearch(NameSearch searchTerms)
        {

            if (string.IsNullOrEmpty(searchTerms.ScientificName))
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
