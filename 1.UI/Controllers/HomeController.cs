using _1.UI.Models;
using _2.BL;
using _3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1.UI.Controllers
{
    public class HomeController : Controller
    {
        Manager manager;
        public HomeController()
        {
            manager = new Manager();
        }

        public ActionResult Index()
        {
            var allCities = manager.Cities().ToList();
            return View(allCities);
        }

        public JsonResult GetAllCities()
        {
            List<CityesVM> allCities;

            var temp = manager.Cities();
            allCities = new List<CityesVM>();

            foreach (var c in temp)
            {
                allCities.Add(new CityesVM(c.cityId, c.cityName.ToUpper()));
            }
            return Json(allCities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllStreetes(int cityId)
        {
            List<StreetesVM> allStreetes;

            var temp = manager.Streetes().Where(s => s.cityId == cityId);
            allStreetes = new List<StreetesVM>();

            foreach (var s in temp)
            {
                allStreetes.Add(new StreetesVM(s.streetId, s.streetName.ToLower(), s.cityId));
            }
            return Json(allStreetes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateView()
        {
            return View();
        }

        public ActionResult Create(string cityId, string cityName, string streetName)
        {
            if (streetName != "")//1 
            {
                if (!cityId.Contains("select city") && cityName == "")//2
                {
                    var cityToAdd = manager.Cities().Where(c => c.cityId == int.Parse(cityId)).FirstOrDefault();
                    Street street = new Street()
                    {
                        streetName = streetName,
                        cityId = int.Parse(cityId)
                    };
                    manager.InsertStreet(street);
                    return RedirectToAction("Index");
                }
                else  
                {
                    if (cityId.Contains("select city") && cityName != "")//3
                    {
                        City city = new City()
                        {
                            cityName = cityName
                        };
                        manager.InsertCity(city);

                        var cityToAdd = manager.Cities().Where(c => c.cityName == cityName).FirstOrDefault();
                        Street street = new Street()
                        {
                            streetName = streetName,
                            cityId = cityToAdd.cityId
                        };
                        manager.InsertStreet(street);

                        return RedirectToAction("Index");
                    }
                    else return View(); // ---->   cityId= Exist City OR cityName = null. return Error. //3
                }
            }
            else // streetName==Null ----> return som Error //1
            { 
                return RedirectToAction("Index");
            }
        }
    }
}