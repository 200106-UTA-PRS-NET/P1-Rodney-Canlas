using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Library.SessionObjects;
using PizzaBox.Library.Interfaces;
using PizzaBox.Library.Models;
using PizzaBox.WebUI.Models;
using PizzaBox.Library.Dependencies;

namespace PizzaBox.WebUI.Controllers
{
    public class MenuController : Controller
    {
        public IUserOrderRepo _orderRepo;
        public IStoreRepo _storeRepo;
        public IAccountRepo _accountRepo;
        
        public MenuController(IUserOrderRepo orderRepo, IStoreRepo storeRepo, IAccountRepo accountRepo)
        {
            _orderRepo = orderRepo;
            _storeRepo = storeRepo;
            _accountRepo = accountRepo;
        }
        
        public ActionResult WhichMenu()
        {
            CurrentOrderContent.orderContent = new List<Pizza>();
            CurrentOrderContent.totalCost = Convert.ToDecimal(0.00);
            
            if (CurrentUser.isAdmin)
            {
                return RedirectToAction(nameof(AdminMenu));
            }
            else
            {
                return RedirectToAction(nameof(UserMenu));
            }
        }
        // GET: Menu/AdminUser
        public ActionResult AdminMenu()
        {
            return View();
        }
        
        // GET: Menu/UserMenu
        public ActionResult UserMenu()
        {
            string test = CurrentUser.FirstName;
            return View();
        }

        public ActionResult MakeOrder()
        {
            return RedirectToRoute(new
            {
                controller = "Order",
                action = "ChooseStore",
                id = CurrentUser.Id
            });
        }

        public ActionResult ViewOrderHistory()
        {
            Dictionary<int, string> storeDictionary = Dictionary.StoreDictionary();
            IEnumerable<UserOrder> orders = _orderRepo.GetOrdersByUserID(CurrentUser.Id);
            IEnumerable<OrderHistoryViewModel> userOrderViewModels = orders.Select(x => new OrderHistoryViewModel
            {
                StoreName = storeDictionary[x.StoreId],
                OrderDateTime = x.OrderDateTime,
                TotalCost = x.TotalCost,
                OrderContent = Utilities.DeserializeFromXMLString(x.OrderContent)
            });

            return View(userOrderViewModels);
        }

        public ActionResult AccessStoreData()
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

        public ActionResult CompletedOrders(int id)
        {
            IEnumerable<Account> accounts = _accountRepo.GetAccounts();
            Dictionary<int, string> accountDictionary = Dictionary.AccountDictionary(accounts);
            IEnumerable<UserOrder> orders = _orderRepo.GetOrdersByStoreID(id);
            IEnumerable<CompletedOrdersViewModel> completedOrdersViewModels = orders.Select(x => new CompletedOrdersViewModel
            {
 
                FullName = accountDictionary[x.UserId],
                OrderDateTime = DateTime.Now,
                TotalCost = x.TotalCost,
                OrderContent = Utilities.DeserializeFromXMLString(x.OrderContent)
            }) ;
            ViewData["StoreName"] = Dictionary.StoreDictionary()[id];

            return View(completedOrdersViewModels);
        }

        public ActionResult SignOut()
        {
            CurrentUser.isAdmin = false;
            CurrentUser.Id = 0;
            CurrentUser.Username = null;
            CurrentUser.Passphrase = null;
            CurrentUser.FirstName = null;
            CurrentUser.LastName = null;

            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index",
                id = CurrentUser.Id
            });
        }      
    }
}