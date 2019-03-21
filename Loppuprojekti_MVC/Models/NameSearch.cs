using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loppuprojekti_MVC.Models
{
    public class NameSearch
    {
        public int Taxonid { get; set; }
        public string MainCommonName { get; set; }
        public string ScientificName { get; set; }
        public string Category { get; set; }
        public string PopulationTrend { get; set; }

    }
}
