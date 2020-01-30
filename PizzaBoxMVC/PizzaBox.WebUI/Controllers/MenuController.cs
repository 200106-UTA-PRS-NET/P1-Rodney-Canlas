using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Library.SessionObjects;

namespace PizzaBox.WebUI.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu/AdminUser
        public ActionResult AdminMenu()
        {
            return View();
        }
        
        // GET: Menu/UserMenu
        public ActionResult UserMenu()
        {
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
            return Content("You are viewing order history.");
        }

        public ActionResult AccessStoreData()
        {
            return Content("You are accessing store data.");
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

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
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

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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