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
    //TODO: Initialize RestUtil in field, then just call it in all the methods

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

            //PartialView
            IndividualSpeciesViewModel vm = new IndividualSpeciesViewModel();
            vm.Species = _as.FirstOrDefault();
            vm.Narrative = _rs.SingleNarrative(searchTerms).FirstOrDefault();

            return View(vm);
            //return View(_as[0]); //ennen partialView:tä
            //return View(_as.FirstOrDefault());
        }

        // GET individual info for individual species, /Species/SingleSpecies
        public ActionResult SingleNarrative(string searchTerms)
        {
            RestUtil _rs = new RestUtil();
            var _as = _rs.SingleNarrative(searchTerms);

            return View(_as[0]);
        }

        //TODO: Get this working, would be funny :) 
        // GET IUCN page for individual species
        public ActionResult IUCNurl(string searchTerms)
        {
            RestUtil _rs = new RestUtil();
            var _as = _rs.IUCNurl(searchTerms);

            //ViewBag.Link = _as;
            //return View(_as.Rlurl);
            return ViewBag(_as.Rlurl);
        }

        //TODO: Get this working for statistics
        // GET IUCN for count of species in different vulnerability classes
        //searchTerm: vulnerability class
        public ActionResult SCategory(string searchTerms)
        {
            RestUtil _rs = new RestUtil();
            var _sc = _rs.SCategory(searchTerms);
            return ViewBag(_sc.Count);
        }

    }
}