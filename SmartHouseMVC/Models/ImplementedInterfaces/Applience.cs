using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseMVC.Models.Interfaces;
namespace SmartHouseMVC.Models.ImplementedInterfaces
{
    public abstract class Applience: ISwitchable
    {
        private bool state;
        private string name;
        public string Name
        {
            protected set
            {
                name = value;
            }
             get
        {
            return name;
        }
        }
        public bool State
        {
            set
            {
                state = value;
            }
            get
            {
                return state;
            }
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
        public virtual string ShowStatus()
        {
            string status = " ";
            if (State)
                status = name+" is on " ;
            else
                status = name+" is off";
            return status;
        }
    }
}