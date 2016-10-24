using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.ImplementedInterfaces;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.Factory
{
    public class ConditionerCreator:ApplienceFactory
    {
        public override ISwitchable CreateSwitchable()
        {
            return new Conditioner("Conditioner", 25);
        }
    }
}