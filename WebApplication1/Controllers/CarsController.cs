using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        private CarDBCtxt baza = new CarDBCtxt();
        // GET: Cars
        public ActionResult Index()
        {
            return View(baza.Cars.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id,Brand,Model,Price,Bought,Sold")] Car car)
        {
            if (ModelState.IsValid)
            {
                baza.Cars.Add(car);
                baza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
    }
    
}