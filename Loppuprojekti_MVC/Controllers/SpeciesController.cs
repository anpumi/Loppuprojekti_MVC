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
        private RestUtil _rs = new RestUtil();
        //PartialView
        IndividualSpeciesViewModel vm = new IndividualSpeciesViewModel();

        // GET species, /Species
        public ActionResult SpeciesIndex(string searchTerms = "a")
        {
            searchTerms = searchTerms.ToLower();
            RestUtil rs = new RestUtil();
            List<Species> sp = rs.Species().Where(t => t.ScientificName.ToLower().StartsWith(searchTerms)).OrderBy(c => c.ScientificName).ToList();

            ViewBag.Letters = string.Join("", rs.Species().OrderBy(t => t.ScientificName).Select(t => t.ScientificName.Substring(0, 1)).Distinct());

            var _species = _rs.Species();

            return View(sp);

        }

        // GET individual info for individual species, /Species/SingleSpecies
        public ActionResult SingleSpecies(string searchTerms)
        {
            var _as = _rs.SingleSpecies(searchTerms);
            if (_as.Count == 0)
            {
                TempData["Errormessage"] = "No results for your search, please check the spelling. If you have trouble, check http://www.sciname.info/";
                return RedirectToAction("Index", "Home");
            }
            //PartialView, vm contains needed Models
            vm.Species = _as.FirstOrDefault();
            vm.Narrative = _rs.SingleNarrative(searchTerms).FirstOrDefault();
            vm.Link = _rs.IUCNurl(searchTerms);
            return View(vm);

            //return View(_as[0]); //ennen partialView:tä
            //return View(_as.FirstOrDefault());
        }

        public ActionResult ENSingleSpecies(string searchTerms)
        {
            RestUtil ru = new RestUtil();
            var endangeredSpecies = ru.SingleSpecies(searchTerms).Where(c => c.Category == "EN");
            return View(endangeredSpecies);
        }

        // GET individual info for individual species, /Species/SingleSpecies
        public ActionResult SingleNarrative(string searchTerms)
        {
            var _as = _rs.SingleNarrative(searchTerms);
            return View(_as[0]);
        }

        // GET IUCN page for individual species
        public ActionResult IUCNurl(string searchTerms)
        {
            var _ls = _rs.IUCNurl(searchTerms);

            //ViewBag.Link = _as;
            return View(_ls.Rlurl);
            //return ViewBag(_ls.Rlurl);
        }

        // GET IUCN for count of species in different vulnerability classes
        //searchTerm: vulnerability class
        public ActionResult SCategory(string searchTerms = "A")
        {
            //searchTerms = searchTerms.ToLower(); // ei saa olla: kosahtaa!
            RestUtil rs = new RestUtil();
            List<Species> sp = rs.Species().Where(t => t.ScientificName.StartsWith(searchTerms)).OrderBy(c => c.ScientificName).ToList();

            ViewBag.Letters = string.Join("", rs.Species().OrderBy(t => t.ScientificName).Select(t => t.ScientificName.Substring(0, 1)).Distinct());

            var _species = _rs.Species();

            IndividualSpecies ind = new IndividualSpecies();
            if (searchTerms == "EX")
            {
                ViewBag.ST = "Extinct";
                ViewBag.DS = "A taxon is extinct when there is no reasonable doubt that the last individual has died. A taxon is presumed extinct when exhaustive surveys in known and/or expected habitat, at appropriate times (diurnal, seasonal, annual), throughout its historic range have failed to record an individual. Surveys should be over a time frame appropriate to the taxon’s life cycle and life form.";
            }
            else if (searchTerms == "EW")
            {
                ViewBag.ST = "Extinct in the wild";
                ViewBag.DS = "A taxon is extinct in the wild when it is known only to survive in cultivation, in captivity or as a naturalized population (or populations) well outside the past range. A taxon is presumed extinct in the wild when exhaustive surveys in known and/or expected habitat, at appropriate times (diurnal, seasonal, annual), throughout its historic range have failed to record an individual. Surveys should be over a time frame appropriate to the taxon’s life cycle and life form.";
            }
            else if (searchTerms == "CR")
            {
                ViewBag.ST = "Critically endangered";
                ViewBag.DS = "A taxon is critically endangered when the best available evidence indicates that it meets any of the criteria A to E for critically endangered, and it is therefore considered to be facing an extremely high risk of extinction in the wild.";
            }
            else if (searchTerms == "EN")
            {
                ViewBag.ST = "Endangered";
                ViewBag.DS = "A taxon is endangered when the best available evidence indicates that it meets any of the criteria A to E for endangered, and it is therefore considered to be facing a very high risk of extinction in the wild.";
            }
            else if (searchTerms == "VU")
            {
                ViewBag.ST = "Vulnerable";
                ViewBag.DS = "A taxon is vulnerable when the best available evidence indicates that it meets any of the criteria A to E for vulnerable, and it is therefore considered to be facing a high risk of extinction in the wild.";
            }

            var _sc = _rs.SCategory(searchTerms);
            return View(_sc);
        }

    }
}