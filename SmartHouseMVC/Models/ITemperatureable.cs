using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseMVC.Models
{
   public interface ITemperatureable
    {
        int Temperature { get; set; }
        string Airconditioning { get; }
        void AirConditioning();
    }
}
