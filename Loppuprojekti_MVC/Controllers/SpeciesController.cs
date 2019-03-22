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
        // TODO: parametria ei ole lisätty Startup.cs routeen...
        public ActionResult SingleSpecies(string searchTerms)
        {
            //alla oleva ei toimi
            //RestUtil _is = new RestUtil().SingleSpecies().Single(i => i.MainCommonName == name);

            //searchTerms ei valu läpi



            RestUtil _rs = new RestUtil();
            var _as = _rs.SingleSpecies(searchTerms);

            //alla aiempi versio
            //var _as = _rs.SingleSpecies(searchTerms);

            //palauttaa listan, kutsu eka olio
            return View(_as[0]);
            //return View(_as.FirstOrDefault());

        }

    }
}