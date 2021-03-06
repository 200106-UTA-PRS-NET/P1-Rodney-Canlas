﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Library.Interfaces;
using PizzaBox.Library.Models;
using PizzaBox.WebUI.Models;
using PizzaBox.Library.SessionObjects;
using PizzaBox.Library.Dependencies;


namespace PizzaBox.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IStoreRepo _storeRepo;
        public IUserOrderRepo _orderRepo;

        public OrderController(IStoreRepo storeRepo, IUserOrderRepo orderRepo)
        {
            _storeRepo = storeRepo;
            _orderRepo = orderRepo;
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
            IEnumerable<UserOrder> orders = _orderRepo.GetOrdersByStoreID(id);
            bool canOrderFromStore = Utilities.CanOrderFromLocation(CurrentUser.Id, orders);
            if (canOrderFromStore)
            {

                Store store = _storeRepo.GetStoreByStoreID(id);

                CurrentStore.Id = store.Id;
                CurrentStore.StoreName = store.StoreName;
                CurrentStore.City = store.City;
                CurrentStore.State = store.State;
                CurrentStore.Zipcode = store.Zipcode;

                return RedirectToAction(nameof(PizzaType));
            } else
            {
                return RedirectToAction(nameof(CannotOrderFromLocation));
            }
        }

        public ActionResult CannotOrderFromLocation()
        {
            return View();
        } 

        public ActionResult PizzaType()
        {
            return View();
        }
        
        // GET: Order/PresetPizza
        public ActionResult PresetPizza()
        {
            ViewData["Toppings"] = PresetType.Toppings();
            ViewData["Crusts"] = PresetType.Crusts();
            ViewData["Sizes"] = PresetType.Sizes();

            return View();
        }

        // POST: Order/PresetPizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PresetPizza(PizzaViewModel pizzaViewModel)
        {
            Pizza newPizza = new Pizza()
            {
                PizzaType = "Preset",
                Crust = pizzaViewModel.Crust,
                Size = pizzaViewModel.Size,
                Toppings = new List<string>() { pizzaViewModel.Topping }
            };
            decimal costOfPizza = Utilities.Cost(pizzaViewModel.Size);

            
            for (int i = 0; i < pizzaViewModel.Count; i++)
            {
                CurrentOrderContent.orderContent.Add(newPizza);
                CurrentOrderContent.totalCost += costOfPizza;
            }
                return RedirectToAction(nameof(Deciding));
        }

        public ActionResult CustomPizza()
        {
            return Content("You are making a custom pizza.");
        }

        public ActionResult Deciding()
        {
            return View();
        }

        public ActionResult ConfirmOrder()
        {
            if (CurrentOrderContent.totalCost <= 250)
            {
                string orderContent = Utilities.SerializeToXMLString(CurrentOrderContent.orderContent);
                UserOrder newOrder = new UserOrder()
                {
                    StoreId = CurrentStore.Id,
                    UserId = CurrentUser.Id,
                    OrderContent = orderContent,
                    TotalCost = CurrentOrderContent.totalCost,
                    OrderDateTime = DateTime.Now
                };
                _orderRepo.AddOrder(newOrder);
                _orderRepo.Save();

                return RedirectToAction(nameof(OrderConfirmed));
            }
            else
            {
                return RedirectToAction(nameof(DeleteOrder));
            }
        }

        public ActionResult DeleteOrder()
        {
            CurrentOrderContent.orderContent = new List<Pizza>();
            CurrentOrderContent.totalCost = Convert.ToDecimal(0.00);

            return RedirectToAction(nameof(OrderDeleted));
        }

        public ActionResult OrderConfirmed()
        {
            CurrentOrderContent.orderContent = new List<Pizza>();
            CurrentOrderContent.totalCost = Convert.ToDecimal(0.00);

            return View();
        }

        public ActionResult OrderDeleted()
        {
            return View();
        }
    }
}