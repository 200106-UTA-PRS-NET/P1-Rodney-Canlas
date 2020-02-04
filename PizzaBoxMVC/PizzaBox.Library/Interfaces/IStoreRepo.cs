using System.Collections.Generic;
using PizzaBox.Library.Models;

namespace PizzaBox.Library.Interfaces
{
    public interface IStoreRepo
    {
        IEnumerable<Store> GetStores();

        Store GetStoreByStoreID(int id);

    }
}
