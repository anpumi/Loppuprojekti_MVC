using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Loppuprojekti_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Loppuprojekti_MVC.Controllers
{
     //only search logic, GET logic in Models.RestUtil 
    public class SpeciesController : Controller
    {
        // GET species, /Species
        public ActionResult SpeciesIndex() 
        {
            RestUtil _rs = new RestUtil();
            var _species = _rs.Species();
            
            return View(_species);
        }

        // GET individual info for individual species, /Species/SingleSpecies
        public ActionResult SingleSpecies(string searchTerms)
        {
            RestUtil _rs = new RestUtil();
            var _as = _rs.SingleSpecies(searchTerms);

            return View(_as[0]);
            //return View(_as.FirstOrDefault());
        }

        // GET individual info for individual species, /Species/SingleSpecies
        public ActionResult SingleNarrative(string searchTerms)
        {
            RestUtil _rs = new RestUtil();
            var _as = _rs.SingleNarrative(searchTerms);

            //return View(_as.FirstOrDefault());
            return View(_as[0]);
        }

    }
}