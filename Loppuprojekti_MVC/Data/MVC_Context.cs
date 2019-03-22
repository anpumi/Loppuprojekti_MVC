using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Loppuprojekti_MVC.Data
{
    public class MVC_Context : DbContext
    {
        public MVC_Context(DbContextOptions<MVC_Context> options)
          : base(options)
        {
        }

        public DbSet<Loppuprojekti_MVC.Models.IndividualSpecies> IndividualSpecies { get; set; }
    }
}
