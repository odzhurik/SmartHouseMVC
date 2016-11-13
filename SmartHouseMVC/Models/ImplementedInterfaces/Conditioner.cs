using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public class Conditioner:Applience, ITemperatureable
    {

       

        public int DefaultTemp
        {
            get ; 
            set ; 
        }
        public string Airconditioning
        {
            get;
            set;
        }
        public Conditioner()
        {
                
        }
        public Conditioner(string name, int temp)
        {
            DefaultTemp = temp;
            Name = name;
        }
        public int Temperature
        {
            set;
            get;
        }
        public void AirConditioning()
        {
            if (Temperature > DefaultTemp)

                Airconditioning = "heated to " + Temperature;

            else
                Airconditioning = "cooled to " + Temperature;

            DefaultTemp = Temperature;
        }
        public override string ToString()


        {
            string status = base.ToString();
            if (State)
                status += " current temperature is " + DefaultTemp + " C";
            return status;
        }


    }
}