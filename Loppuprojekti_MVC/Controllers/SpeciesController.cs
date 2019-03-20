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
        // GET species
        // /Species
        public ActionResult SpeciesIndex() 
        {
            //tää ei toimi
            RestUtil _rs = new RestUtil();
            var _species = _rs.Species();
            
            return View(_species);
            //return View(_rs.Species().OrderBy(s => s.ScientificName));
        }

        // GET individual info for individual species
        // /Species/SingleSpecies
        // TODO: parametria ei ole lisätty Startup.cs routeen...
        public ActionResult SingleSpecies(string name)
        {
            RestUtil _rs = new RestUtil();
            return View(_rs.SingleSpecies(name));
        }

    }
}