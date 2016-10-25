using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
using SmartHouseMVC.Models.ImplementedInterfaces;
namespace SmartHouseMVC.Models.Factory
{
    public class MicrowaveCreator: ApplienceFactory
    {
        public override Applience CreateApplience()
        {
            return new Microwave("Microwave", 50, 250);
        }
    }
}