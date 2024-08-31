using MVCProjectImplementationOfMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProjectImplementationOfMasterDetails.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("db")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AllowanceCategory> AllowanceCategories { get; set; }
        public DbSet<AllowanceType> AllowanceTypes { get; set; }
        public DbSet<Details> Details { get; set; }

    }
}