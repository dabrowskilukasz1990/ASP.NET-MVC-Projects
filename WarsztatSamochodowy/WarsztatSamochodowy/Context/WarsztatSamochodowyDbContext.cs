using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WarsztatSamochodowy.Models;

namespace WarsztatSamochodowy.Context
{
    public class WarsztatSamochodowyDbContext :DbContext
    {
        public DbSet<Car> car { get; set; }
        public DbSet<Employee> employee { get; set; }


    }
}