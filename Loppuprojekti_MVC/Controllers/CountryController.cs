using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loppuprojekti_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loppuprojekti_MVC.Controllers
{
    public class CountryController : Controller
    {
        private CountryUtil ct = new CountryUtil();

        // GET: Countries
        public ActionResult CountryIndex(string firstLetter = "a")
        {
            firstLetter = firstLetter.ToLower();
            List<CountryList> ctrs = ct.Countries().Where(t => t.Country.ToLower().StartsWith(firstLetter)).ToList();
            ViewBag.Letters = string.Join("", ct.Countries().OrderBy(t => t.Country).Select(t => t.Country.Substring(0, 1)).Distinct());
            return View(ctrs);
        }

        public ActionResult Country(string country) // the parameter needed to use string interpolation in CountryUtil
        {
            CountryUtil cu = new CountryUtil();
            var countryspecies = cu.Country(country);
            return View(countryspecies);
        }

        //GET countries working version
        //public ActionResult CountryIndex(/*string firstLetter="a"*/)
        //{
        //    CountryUtil ct = new CountryUtil();
        //    //firstLetter = firstLetter.ToLower();
        //    //List<CountryList> countries = ct.Countries
        //    var countries = ct.Countries();
        //    return View(countries);
        //}


    }
}