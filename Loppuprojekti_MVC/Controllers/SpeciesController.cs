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
        //only search logic, GET logic in Models.RestUtil
        public ActionResult SpeciesIndex() 
        {
            RestUtil _rs = new RestUtil();
            return View(_rs.Species());
        }

    }
}