using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Library.Interfaces;
using PizzaBox.Library.Models;
using PizzaBox.WebUI.Models;
using PizzaBox.Library.SessionObjects;


namespace PizzaBox.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IStoreRepo _storeRepo;

        public OrderController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        // GET: Order/ChooseLocation
        public ActionResult ChooseStore()
        {
            IEnumerable<Store> stores = _storeRepo.GetStores();
            IEnumerable<StoreViewModel> storeViewModels = stores.Select(x => new StoreViewModel
            {
                Id = x.Id,
                StoreName = x.StoreName,
                City = x.City,
                State = x.State,
                Zipcode = x.Zipcode
            });
            return View(storeViewModels);
        }

        // GET: Order/ChooseLocation

        public ActionResult ChoseStore(int id)
        {
            try
            {
                Store store = _storeRepo.GetStoreByID(id);
                
                CurrentStore.Id = store.Id;
                CurrentStore.StoreName = store.StoreName;
                CurrentStore.City = store.City;
                CurrentStore.State = store.State;
                CurrentStore.Zipcode = store.Zipcode;
                
                return RedirectToAction(nameof(PizzaType));
            }
            catch
            {
                return RedirectToAction(nameof(ChooseStore));
            }
        }

        public ActionResult PizzaType()
        {
            return View();
        }
         
        public ActionResult PresetPizza()
        {
            return View();
        }

        public ActionResult CustomPizza()
        {
            return Content("You are making a custom pizza.");
        }
        
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}