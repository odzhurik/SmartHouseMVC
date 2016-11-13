using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public class Lamp : Applience, IChangeable
    {
        

        public int Max
        {
            get;
            set;
        }
        public Lamp()
        {

        }
        public Lamp(string name,int unit, int max)
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

        public void Up()
        {
            if (State)
            {
                if (Unit == Max)
                    Unit = 10;
                else
                    Unit += 10;
            }
        }
        public void Down()
        {
            if (State)
            {
                if (Unit == 10)
                    Unit = Max;
                else
                    Unit -= 10;
            }
        }
        public override string ToString()

        {
            string status = base.ToString();
            if(State)
            {
                status += " current brightness " + Unit;
            }
            return status;
        }
    }

}