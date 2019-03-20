﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Loppuprojekti_MVC.Models
{
    /// <summary> 
    /// IUCN REST connection and GET
    /// </summary>
    public class RestUtil
    {
        //miksi nämä antaa errorin?
        //const url = $"http://apiv3.iucnredlist.org/api/v3/";
        //const token = "9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee";

        //GET action for all species from IUCN 
        //IUCN returns JSON Objects!
        // /species/
        public List<Species> Species()
        {
             string json = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //TODO:kovakoodattu osoite & token, muuta
                //TODO:pistä if - jos ei ekassa setissä, niin tokassa, kolmannessa....
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/page/0?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            SpeciesRootObject res; 
            res = JsonConvert.DeserializeObject<SpeciesRootObject>(json);
            return res.Result;
        }

        //GET individual info for a species
        // /species/name
        public List<IndividualSpecies> SingleSpecies(string name)
        {
            string json = "";
            string searchTerm = name;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //kovakoodattu testi versio
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/loxodonta%20africana?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                //oikea on alla
                //var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/{searchTerm}?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }
            IndividualSpeciesRoot res;
            res = JsonConvert.DeserializeObject<IndividualSpeciesRoot>(json);
            return res.Result;
        }



    }
}