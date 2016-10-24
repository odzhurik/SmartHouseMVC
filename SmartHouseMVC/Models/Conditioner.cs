using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class Conditioner:Applience, ITemperatureable
    {
        
        private int defaultTemp;
        public string Airconditioning
        {
            get;
            private set;
        }
        public Conditioner(string name, int temp)
        {
            defaultTemp = temp;
            Name = name;
        }
        public int Temperature
        {
            set;
            get;
        }
        public void AirConditioning()
        {
            if (Temperature > defaultTemp)

                Airconditioning = "heated to " + Temperature;

            else
                Airconditioning = "cooled to " + Temperature;

            defaultTemp = Temperature;
        }
        public override string ShowStatus()
        {
            string status = base.ShowStatus();
            if (State)
                status += " current temperature is " + defaultTemp + " C";
            return status;
        }


    }
}