using Newtonsoft.Json;
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
        //GET action for all species from IUCN, /species/
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
        public List<IndividualSpecies> SingleSpecies(string searchTerms)
        {
            //TODO: virhekäsittely
            string json = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //kovakoodattu testi versio
                //var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/loxodonta%20africana?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/{searchTerms}?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }

            IndividualSpeciesRoot res;
            res = JsonConvert.DeserializeObject<IndividualSpeciesRoot>(json);
            return res.Result;

        }

        public List<IndividualSpecies> SingleSpeciesId(int searchTerms)
        {
            //TODO: virhekäsittely
            string json = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //kovakoodattu testi versio
                //var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/loxodonta%20africana?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/id/{searchTerms}?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }

            IndividualSpeciesRoot res;
            res = JsonConvert.DeserializeObject<IndividualSpeciesRoot>(json);
            return res.Result;

        }

        //http://apiv3.iucnredlist.org/api/v3/species/id/12392?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee

        //GET narrative info for a species
        // /species/name
        public List<SpeciesNarrative> SingleNarrative(string searchTerms)
        {
            //TODO: virhekäsittely
            string json = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/narrative/{searchTerms}?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
                //below a test version, trying to remove the html from json: ?json=true doesn't work :/
                //var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/species/narrative/{searchTerms}?json=true?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;

                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }

            SpeciesNarrativeRoot res;
            res = JsonConvert.DeserializeObject<SpeciesNarrativeRoot>(json);
            return res.Result;
        }

        //TODO: Make this work, would be funny :)
        //GET link to IUCNpage of the animal
        public Link IUCNurl(string searchTerms)
        {
        http://apiv3.iucnredlist.org/api/v3/weblink/loxodonta%20africana
            //TODO: virhekäsittely
            string json = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"http://apiv3.iucnredlist.org/api/v3/weblink/{searchTerms}").Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                json = responseString;
            }

            Link res;
            res = JsonConvert.DeserializeObject<Link>(json);
            return res;
        }

    }
}
