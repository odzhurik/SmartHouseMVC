using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models.Interfaces;
using SmartHouseMVC.Models.ImplementedInterfaces;
using SmartHouseMVC.Models.Factory;

namespace SmartHouseMVC.Controllers
{
    public class ApplienceController : Controller
    {
        // GET: Applience
        IList<string> listOfChannels = new List<string> { "MTV", "1+1", "ICTV", "2+2" };
        public ActionResult Index()
        {
            IDictionary<int, ISwitchable> applienceDictionary;

            if (Session["Apps"] == null)
            {
                ApplienceFactory app= new LampCreator();
                applienceDictionary = new SortedDictionary<int, ISwitchable>();
                applienceDictionary.Add(1, app.CreateSwitchable());
                app = new ConditionerCreator();
                applienceDictionary.Add(2, app.CreateSwitchable());
                app=new MicrowaveCreator();
                applienceDictionary.Add(3,app.CreateSwitchable() );
                app = new TVCreator();
                applienceDictionary.Add(4, app.CreateSwitchable());

                Session["Apps"] = applienceDictionary;
                Session["NextId"] = 5;
            }
            else
            {
                applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            }

            SelectListItem[] appList = new SelectListItem[4];
            appList[0] = new SelectListItem { Text = "Lamp", Value = "lamp", Selected = true };
            appList[1] = new SelectListItem { Text = "Conditioner", Value = "conditioner" };
            appList[2] = new SelectListItem { Text = "Microwave", Value = "microwave" };
            appList[3] = new SelectListItem { Text = "TV", Value = "tv" };
            ViewBag.AppList = appList;

            return View(applienceDictionary);
        }
        public ActionResult Add(string app)
        {
            ISwitchable newApp;
            ApplienceFactory appCreate;

            switch (app)
            {
                   
                default:
                    appCreate = new LampCreator();
                    newApp = appCreate.CreateSwitchable();
                    break;
                case "conditioner":
                    appCreate = new ConditionerCreator();
                    newApp = appCreate.CreateSwitchable();
                    break;
                case "microwave":
                    appCreate = new MicrowaveCreator();
                    newApp = appCreate.CreateSwitchable();
                    break;
                case "tv":
                    appCreate = new TVCreator();
                    newApp = appCreate.CreateSwitchable();
                    break;
            }

            int id = (int)Session["NextId"];
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            applienceDictionary.Add(id, newApp);
            id++;
            Session["NextId"] = id;

            return RedirectToAction("Index");
        }

        public ActionResult Switch(int id)
        {
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            ISwitchable app = applienceDictionary[id];
            app.OnOff();

            return RedirectToAction("Index");
        }
        public ActionResult Change(int id, string action)
        {
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];


            IChangeable app = applienceDictionary[id] as IChangeable;

            switch (action)
            {
                case "Down":
                    app.Down();
                    break;
                case "Up":
                    app.Up();
                    break;
            }

            return RedirectToAction("Index");

        }
        public ActionResult Temperature(int id, string action, string temperatureTB)
        {
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            ITemperatureable app = applienceDictionary[id] as ITemperatureable;
            if (action == "Temperature")
            {
                app.Temperature = Convert.ToInt32(temperatureTB);
                app.AirConditioning();
                TempData["conditioner"] = app.Airconditioning;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Cook(int id, string action)
        {
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            ICook app = applienceDictionary[id] as ICook;
            if (action == "Food")
            {
                app.Food = true;

                app.Cook();
            }
            return RedirectToAction("Index");
        }
        public ActionResult ChannelMethod(int id, string action, string channelTV)
        {
            IList<string> list;
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            IChannel app = applienceDictionary[id] as IChannel;
            switch (action)
            {

                case "DeleteChannel":
                    app.DeleteCurrentCh();
                    break;
                case "AddChannel":
                    app.AddChannel(channelTV);
                    break;
                case "Prev":
                    app.PrevChannel();
                    break;
                case "Next":
                    app.NextChannel();
                    break;

                case "show":
                    list = app.ShowChannels();
                    TempData["List"] = list;
                    break;

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            IDictionary<int, ISwitchable> applienceDictionary = (SortedDictionary<int, ISwitchable>)Session["Apps"];
            applienceDictionary.Remove(id);
            return RedirectToAction("Index");
        }
    }
}