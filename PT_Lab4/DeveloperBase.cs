using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PT_Lab4
{
    class DeveloperBase : DbContext
    {
        public DeveloperBase(){
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = $"D:\\db";
            DbPath = System.IO.Path.Combine(path, "PTL4.mdf");            
    }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public string DbPath { get; }


    }
}
