using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loppuprojekti_MVC.Models
{
    /// <summary> RedList Species </summary>
    public class Species
    {
        /// <summary>The TaxonId property represents the Id for the Species/Taxon.</summary>
        /// <value>The TaxonId property gets set with the int of the GET call.</value>
        public int Taxonid { get; set; }
        public string KingdomName { get; set; }
        public string PhylumName { get; set; }
        public string ClassName { get; set; }
        public string OrderName { get; set; }
        public string FamilyName { get; set; }
        public string GenusName { get; set; }
        public string ScientificName { get; set; }
        public string InfraRank { get; set; }
        /// <summary>Sub-species, if available.</summary>
        public string InfraName { get; set; }
        /// <summary> Population name, if available. </summary>
        public string Population { get; set; }
        /// <summary> The Red List Category </summary>
        public string Category { get; set; }

    }

    /// <summary>The SpeciesRootObject property represents the JSON Objects the GET returns.</summary>
    public class SpeciesRootObject
    {
        public int Count { get; set; }
        public string Page { get; set; }
        public List<Species> Species { get; set; }
    }
}
