using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
using SmartHouseMVC.Models.ImplementedInterfaces;

namespace SmartHouseMVC.Models.Factory
{
    public class LampCreator: ApplienceFactory
    {
        public override Applience CreateApplience()
        {
            return new Lamp("Lamp", 50, 100);
        }
    }
}