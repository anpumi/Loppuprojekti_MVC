using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loppuprojekti_MVC.Models
{
    /// <summary> Red List available countries </summary>
    public class Countries
    {
        /// <summary>The Isocode property represents the id for the Country.</summary>
        public string Isocode { get; set; } //country short code e.g. "UZ"
        public string Country { get; set; } //full country name e.g. "Uzbekistan"
        /// <summary> Describes all the species in a given country </summary>
        public List<CountrySpecies> countrySpecies; //describes the species in one country
    }

    public class CountrySpecies
    {
        /// <summary>The TaxonId property represents the Id for teh Species/Taxon.</summary>
        /// <value>The TaxonId property gets set with the int of the GET call.</value>
        public int Taxonid { get; set; }
        public string ScientificName { get; set; } //scientific name of the species
        public string Subspecies { get; set; } //only if presents a certain subspecies/variety/form
        public string Rank { get; set; } //taxonomic ranks, either spp, var or for : spp (multiple species eg. Canis spp - multiple Dog species), var (varietas), for (?)

    }
}
