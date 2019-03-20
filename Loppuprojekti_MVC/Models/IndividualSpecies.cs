using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loppuprojekti_MVC.Models
{
    /// <summary> Red List Individual Species by name </summary>
    public class IndividualSpecies
    {
        public int Taxonid { get; set; }
        public string Scientific_name { get; set; }
        public string KingdomName { get; set; }
        public string PhylumName { get; set; }
        public string ClassName { get; set; }
        public string OrderName { get; set; }
        public string FamilyName { get; set; }
        public string GenusName { get; set; }
        /// <summary> Primary name by which the species has been tagged in the Red List </summary>
        public string MainCommonName { get; set; }
        public string Authority { get; set; }
        public int PublishedYear { get; set; }
        public string AssessmentDate { get; set; }
        /// <summary> The Red List Category </summary>
        public string Category { get; set; }
        public string Criteria { get; set; }
        public string PopulationTrend { get; set; }
        /// <summary> True is the species is marine </summary>
        public bool MarineSystem { get; set; }
        /// <summary> True is the species is fresh water </summary>
        public bool FreshwaterSystem { get; set; }
        /// <summary> True is the species is terrestrial </summary>
        public bool TerrestrialSystem { get; set; }
        public string Assessor { get; set; } //Assessors who carried out the assessment
        public string Reviewer { get; set; }
        public object AooKm2 { get; set; }
        public object EooKm2 { get; set; }
        public object ElevationUpper { get; set; }
        public object ElevationLower { get; set; }
        public object DepthUpper { get; set; }
        public object DepthLower { get; set; }
        public object ErrataFlag { get; set; } //true if the assessment is an errata (error) assessment
        public object ErrataReason { get; set; } //The reason for the errata (error) change, if applicable
        public object AmendedFlag { get; set; } //true if the assessment is an errata (error) assessment
        public object AmendedReason { get; set; } //The reason for the amended change, if applicable

    }

    /// <summary>The IndividualSpeciesRoot property represents the JSON Objects the GET returns.</summary>
    public class IndividualSpeciesRoot
    {
        public string Name { get; set; }
        public List<IndividualSpecies> IndividualSpecies { get; set; }
    }
}
