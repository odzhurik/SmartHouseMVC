using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SmartHouseMVC.Models.Factory;
using SmartHouseMVC.Models.ImplementedInterfaces;

namespace SmartHouseMVC.Models.MyDbContext
{
    public class ApplienceContextInitializer : DropCreateDatabaseAlways<ApplienceContext>
    {
        protected override void Seed(ApplienceContext context)
        {
            ApplienceFactory app = new LampCreator();

            context.Lamps.Add((Lamp)app.CreateApplience());

            app = new ConditionerCreator();

            context.Conditioneres.Add((Conditioner)app.CreateApplience());
            app = new MicrowaveCreator();

            context.Microwaves.Add((Microwave)app.CreateApplience());
            app = new TVCreator();
            context.TVs.Add((TV)app.CreateApplience());

            context.SaveChanges();
        }
    }
}