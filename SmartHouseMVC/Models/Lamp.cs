﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseMVC.Models
{
    public class Lamp : Applience, IChangeable
    {
        int max;
        public Lamp(string name,int unit, int max)
        {
            Name = name;
            Unit = unit;
            this.max = max;
        }
        public int Unit
        {
            get;
           private set;
        }

        public void Up()
        {
            if (State)
            {
                if (Unit == max)
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
                    Unit = max;
                else
                    Unit -= 10;
            }
        }
        public override string ShowStatus()
        {
            string status = base.ShowStatus();
            if(State)
            {
                status += " current brightness " + Unit;
            }
            return status;
        }
    }

}