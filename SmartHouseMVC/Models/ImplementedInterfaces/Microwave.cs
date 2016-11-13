using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using SmartHouseMVC.Models.Interfaces;

namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public class Microwave:Applience, IChangeable, ICook
    {
       
      
        public int Max
        {
            get;
            set;
        }
        public Microwave()
        {

        }
        public Microwave(string name, int unit, int max)
        {
            Name = name;
            Unit = unit;
            Max = max;
        }
       
        public int Unit
        {
            get;
            set;
        }
        public bool Food
        {
            set;

            get;

        }
        public void Cook()
        {
            if(Food && State)
            {
                Food = false;
            }
        }
        public void Up()
        {
            if (State)
            {
                if (Unit == Max)
                    Unit = 10;
                else
                    Unit += 50;
            }
        }
        public void Down()
        {
            if (State)
            {
                if (Unit<=0)
                    Unit = Max;
                else
                   
                    Unit -= 50;
                if (Unit == 0)
                    Unit = Max;
            }
        }
        public override string ToString()

        {
            string status = base.ToString();
            if (State)
                status += " current microwave power is " + Unit + " W";
            return status;
        }
        
    }
}