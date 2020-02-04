using PizzaBox.Library.Models;
using System.Collections.Generic;


namespace PizzaBox.Library.Interfaces
{
    public interface IUserOrderRepo
    {
        void AddOrder(UserOrder order);

        void Save();

        IEnumerable<UserOrder> GetOrdersByUserID(int id);

        IEnumerable<UserOrder> GetOrdersByStoreID(int storeId);

    }
}
