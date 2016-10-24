using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.ImplementedInterfaces;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.Factory
{
    public class TVCreator: ApplienceFactory
    {
        public override ISwitchable CreateSwitchable()
        {
            IList<string> listOfChannels = new List<string> { "MTV", "1+1", "ICTV", "2+2" };
            return new TV("TV", 8, 20, listOfChannels, 0);
        }
    }
}