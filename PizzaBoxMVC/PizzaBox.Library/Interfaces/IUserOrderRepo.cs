using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaBox.Library.Interfaces
{
    public interface IUserOrderRepo
    {
        void AddOrder(UserOrder order);
        void Save();
    }
}
