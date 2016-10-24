using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseMVC.Models
{
   public interface IChannel
    {
        void NextChannel();
        void PrevChannel();
        void AddChannel(string channel);
        IList<string> ShowChannels();
        void DeleteCurrentCh();
    }
}
