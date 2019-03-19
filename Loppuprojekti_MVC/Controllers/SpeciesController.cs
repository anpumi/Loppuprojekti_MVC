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
    public class SpeciesController : Controller
    {
 
        public ActionResult SpeciesIndex() 
        {
            ViewBag.Title = "IUCN Red List";
            //tähän kutsu Models.RestUtils - 
            //niin kuin C# junissa? 
            
            return View();
        }

    }
}