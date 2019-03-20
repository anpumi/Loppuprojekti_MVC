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
        public ActionResult SpeciesIndex() 
        {
            RestUtil _rs = new RestUtil();
            return View(_rs.Species());
        }

        // GET individual info for individual species
        public ActionResult SpeciesIndex(string name)
        {
            RestUtil _rs = new RestUtil();
            return View(_rs.SingleSpecies());
        }

    }
}