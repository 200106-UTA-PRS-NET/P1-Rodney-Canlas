using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Library.Models;

namespace PizzaBox.Library.Interfaces
{
    public interface IAccountRepo
    {
        IEnumerable<Account> GetAccounts();
        void AddAccount(Account account);
        void Save();
        IEnumerable<Account> GetAccountsByUsername(string username);
    }
}
