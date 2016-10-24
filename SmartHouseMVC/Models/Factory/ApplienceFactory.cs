using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
using SmartHouseMVC.Models.ImplementedInterfaces;
namespace SmartHouseMVC.Models.Factory
{
    public abstract class ApplienceFactory
    {
        public abstract ISwitchable CreateSwitchable();
       
    }
}