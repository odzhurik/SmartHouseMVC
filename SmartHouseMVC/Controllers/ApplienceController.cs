﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SmartHouseMVC.Models;

namespace SmartHouseMVC.Controllers
{
    public class ApplienceController : Controller
    {
        // GET: Applience
        IList<string> listOfChannels = new List<string> { "MTV", "1+1", "ICTV", "2+2" };
        public ActionResult Index()
        {
            IDictionary<int, Applience> applienceDictionary;

            if (Session["Apps"] == null)
            {
                applienceDictionary = new SortedDictionary<int, Applience>();
                applienceDictionary.Add(1, new Lamp("Lamp", 50, 100));
                applienceDictionary.Add(2, new Conditioner("Conditioner", 25));
                applienceDictionary.Add(3, new Microwave("Microwave", 50, 250));
                applienceDictionary.Add(4, new TV("TV", 8, 20, listOfChannels, 0));

                Session["Apps"] = applienceDictionary;
                Session["NextId"] = 5;
            }
            else
            {
                applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
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
            Applience newApp;

            switch (app)
            {

                default:
                    newApp = new Lamp("Lamp", 50, 100);
                    break;
                case "conditioner":
                    newApp = new Conditioner("Conditioner", 25);
                    break;
                case "microwave":
                    newApp = new Microwave("Microwave", 50, 250);
                    break;
                case "tv":
                    newApp = new TV("TV", 8, 20, listOfChannels, 0);
                    break;
            }

            int id = (int)Session["NextId"];
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
            applienceDictionary.Add(id, newApp);
            id++;
            Session["NextId"] = id;

            return RedirectToAction("Index");
        }

        public ActionResult Switch(int id)
        {
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
            ISwitchable app = applienceDictionary[id];
            app.OnOff();

            return RedirectToAction("Index");
        }
        public ActionResult Change(int id, string action)
        {
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];


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
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
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
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
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
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
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
            IDictionary<int, Applience> applienceDictionary = (SortedDictionary<int, Applience>)Session["Apps"];
            applienceDictionary.Remove(id);
            return RedirectToAction("Index");
        }
    }
}