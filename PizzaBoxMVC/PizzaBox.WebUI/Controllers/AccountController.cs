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
    public class AccountController : Controller
    {
        public IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        
        // GET: Account
        public ActionResult Index()
        {
            IEnumerable<Account> accounts = _accountRepo.GetAccounts();
            IEnumerable<AccountViewModel> accountViewModels = accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
            return View(accountViewModels);
        }

        // GET: Account/SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: Account/SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel signInViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Checks if valid user
                    IEnumerable<Account> accounts = _accountRepo.GetAccountsByUsername(signInViewModel.Username);
                    Account matchingAccount = accounts.FirstOrDefault();
                    if (accounts.Count() != 0 && signInViewModel.Passphrase == matchingAccount.Passphrase)
                    {
                        if (signInViewModel.Username == "admin")
                        {
                            CurrentUser.isAdmin = true;
                        } else
                        {
                            CurrentUser.isAdmin = false;
                        }

                        CurrentUser.Id = matchingAccount.Id;
                        CurrentUser.Username = matchingAccount.Username;
                        CurrentUser.Passphrase = matchingAccount.Passphrase;
                        CurrentUser.FirstName = matchingAccount.FirstName;
                        CurrentUser.LastName = matchingAccount.LastName;

                        if (CurrentUser.isAdmin)
                        {
                            return RedirectToRoute(new
                            {
                                controller = "Menu",
                                action = "AdminMenu",
                                id = CurrentUser.Id
                            });
                        } else
                        {
                            return RedirectToRoute(new
                            {
                                controller = "Menu",
                                action = "UserMenu",
                                id = CurrentUser.Id
                            });
                        }
                    } else
                    {
                        return RedirectToAction(nameof(AccountDoesNotExist));
                    }
                }
                return View(signInViewModel);
            } 
            catch
            {
                return View();
            }
        }
            

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if the username exists
                    IEnumerable<Account> accounts = _accountRepo.GetAccountsByUsername(accountViewModel.Username);
                    if (accounts.Count() == 0)
                    {
                        var newAccount = new Account
                        {
                            Username = accountViewModel.Username,
                            Passphrase = accountViewModel.Passphrase,
                            FirstName = accountViewModel.FirstName,
                            LastName = accountViewModel.LastName
                        };
                        _accountRepo.AddAccount(newAccount);
                        _accountRepo.Save();

                        return RedirectToAction(nameof(SignIn));
                    } 
                    else
                    {
                        return RedirectToAction(nameof(InvalidUsername));
                    }
                }

                return View(accountViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Action/InvalidUsername
        public ActionResult InvalidUsername()
        {
            return View();
        }

        // GET: Action/AccountDoesNotExist
        public ActionResult AccountDoesNotExist()
        {
            return View();
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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