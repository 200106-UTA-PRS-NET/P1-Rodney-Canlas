using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Library.Models;

namespace PizzaBox.Library.Interfaces
{
    public interface IStoreRepo
    {
        IEnumerable<Store> GetStores();
        Store GetStoreByID(int id);
    }
}
