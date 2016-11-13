using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SmartHouseMVC.Models.ImplementedInterfaces;

namespace SmartHouseMVC.Models.MyDbContext
{
    public class ApplienceContext: DbContext
    {
        static  ApplienceContext()
        {
            Database.SetInitializer<ApplienceContext>(new ApplienceContextInitializer());
        }
        public ApplienceContext()
            : base("ApplienceConnection")
        {

        }
      public DbSet<Lamp> Lamps { get; set; }
      public DbSet<TV> TVs { get; set; }
      public DbSet<Microwave> Microwaves { get; set; }
      public DbSet<Conditioner> Conditioneres { get; set; }
     
    }

}