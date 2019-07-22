using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShopMVC.Models;

namespace Pizza_mvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (PizzaEntities3 dbModel = new PizzaEntities3())
            {
                return View(dbModel.pizzas .ToList());
            }
        }

        // GET: Default/Details/5
        public ActionResult Details(int id )
        {
            using (PizzaEntities3 dbModel = new PizzaEntities3())
            return View(dbModel .pizzas .Where (x=> x.Id == id ).FirstOrDefault ());
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(pizza  pizza )
        {
            try
            {
                using (PizzaEntities3 dbModel = new PizzaEntities3())
                {
                    dbModel.pizzas.Add(pizza);
                    dbModel.SaveChanges();
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, pizza pizza )
        {
            try
            {
                using (PizzaEntities3 dbModel = new PizzaEntities3())
                {
                    dbModel.Entry(pizza).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (PizzaEntities3 dbModel = new PizzaEntities3())
                {
                    pizza  piz = dbModel.pizzas .Where(x => x.Id == id).FirstOrDefault(); 
                    dbModel.pizzas.Remove(piz);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
