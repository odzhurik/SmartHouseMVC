using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;

namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public abstract class Applience: ISwitchable
    {

        public int Id { get; set; }
        
        public string Name
        {
           get;set;
        }

        public bool State
        {
            get;
            set;
        }
        public  void OnOff()
        {
            if (State)
            {
                State = false;
            }
            else
            {
                State = true;
            }
        }
        public override string ToString()

        {
            string status = " ";
            if (State)
                status = Name+" is on " ;
            else
                status = Name+" is off";
            return status;
        }
    }
}