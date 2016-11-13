using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouseMVC.Models.Interfaces;
using SmartHouseMVC.Models.ImplementedInterfaces;
using SmartHouseMVC.Models.Factory;
using SmartHouseMVC.Models.MyDbContext;


namespace SmartHouseMVC.Controllers
{
    public class ApplienceController : Controller
    {
        // GET: Applience
        ApplienceContext db = new ApplienceContext();
        public ActionResult Index()
        {
            IList<Applience> list=new List<Applience>();
           
            foreach(Applience item in db.Lamps.ToList())
            {
                list.Add(item);
            }
            foreach(Applience item in db.Conditioneres.ToList())
            {
                list.Add(item);
            }
            foreach(Applience item in db.Microwaves.ToList())
            {
                list.Add(item);
            }
           foreach(Applience item in db.TVs.ToList())
           {
               list.Add(item);
           }

            SelectListItem[] appList = new SelectListItem[4];
            appList[0] = new SelectListItem { Text = "Lamp", Value = "lamp", Selected = true };
            appList[1] = new SelectListItem { Text = "Conditioner", Value = "conditioner" };
            appList[2] = new SelectListItem { Text = "Microwave", Value = "microwave" };
            appList[3] = new SelectListItem { Text = "TV", Value = "tv" };
            ViewBag.AppList = appList;

            return View(list);
        }
        public ActionResult Add(string app)
        {
            Applience newApp;
            ApplienceFactory appCreate;

            switch (app)
            {
                   
                default:
                    appCreate = new LampCreator();
                    newApp = appCreate.CreateApplience();
                    db.Lamps.Add((Lamp)newApp);
                    break;
                case "conditioner":
                    appCreate = new ConditionerCreator();
                    newApp = appCreate.CreateApplience();
                    db.Conditioneres.Add((Conditioner)newApp);
                    break;
                case "microwave":
                    appCreate = new MicrowaveCreator();
                    newApp = appCreate.CreateApplience();
                    db.Microwaves.Add((Microwave)newApp);
                    break;
                case "tv":
                    appCreate = new TVCreator();
                    newApp = appCreate.CreateApplience();
                    db.TVs.Add((TV)newApp);
                    break;
            }
              db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Switch(int id, string name)
        {
            ISwitchable app;
            switch(name)
            {
                
                case "Conditioner":
                    {
                        app = db.Conditioneres.Find(id);
                        break;
                    }
                case "Microwave":
                    {
                        app = db.Microwaves.Find(id);
                        break;
                    }
                case "TV":
                    {
                        app = db.TVs.Find(id);
                        break;
                    }
                default:
                    {
                        app = db.Lamps.Find(id);
                        break;
                    }
            }
         
            app.OnOff();
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Change(int id,string name, string action)
        {
            IChangeable app;
            switch (name)
            {
               
                case "Microwave":
                    {
                        app = db.Microwaves.Find(id);
                        break;
                    }
                case "TV":
                    {
                        app = db.TVs.Find(id);
                        break;
                    }
                default:
                    {
                        app = db.Lamps.Find(id);
                        break;
                    }
            }

            switch (action)
            {
                case "Down":
                    app.Down();
                    break;
                case "Up":
                    app.Up();
                    break;
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Temperature(int id,string name, string action, string temperatureTB)
        {
            ITemperatureable app;
            if(name=="Conditioner")
            {
                app = db.Conditioneres.Find(id);
            }
            else
            {
                app = null;
            }

            if (action == "Temperature")
            {
                app.Temperature = Convert.ToInt32(temperatureTB);
                app.AirConditioning();
                TempData["conditioner"] = app.Airconditioning;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cook(int id,string name, string action)
        {
            ICook app;
            if(name=="Microwave")
            {
                app = db.Microwaves.Find(id);
            }
            else
            {
                app = null;
            }
            if (action == "Food")
            {
                app.Food = true;

                app.Cook();
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChannelMethod(int id,string name, string action, string channelTV)
        {
            IList<string> list;
            IChannel app;
            if(name=="TV")
            {
                app = db.TVs.Find(id);
            }
            else
            {
                app = null;
            }
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
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id,string name)
        {
            Applience app;
            switch (name)
            {

                case "Conditioner":
                    {
                        app = db.Conditioneres.Find(id);
                        db.Conditioneres.Remove((Conditioner)app);
                        break;
                    }
                case "Microwave":
                    {
                        app = db.Microwaves.Find(id);
                        db.Microwaves.Remove((Microwave)app);
                        break;
                    }
                case "TV":
                    {
                        app = db.TVs.Find(id);
                        db.TVs.Remove((TV)app);
                        break;
                    }
                default:
                    {
                        app = db.Lamps.Find(id);
                        db.Lamps.Remove((Lamp)app);
                        break;
                    }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}