using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Library.Interfaces;
using PizzaBox.DataAccess.Entities;
using System.Linq;

namespace PizzaBox.DataAccess.Repositories
{
    public class UserOrderRepo : IUserOrderRepo
    {
        private readonly PizzaBoxDbContext _dbContext;

        public UserOrderRepo(PizzaBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Library.Models.UserOrder order)
        {
            Entities.UserOrder _order = Mapper.Map(order);
            _dbContext.Add(_order);
        }

        public IEnumerable<Library.Models.UserOrder> GetOrdersByStoreID(int storeId)
        {
            IQueryable<Entities.UserOrder> orders = from o in _dbContext.UserOrder
                                                    where o.StoreId == storeId
                                                    select o;

            return orders.Select(Mapper.Map);
        }

        public IEnumerable<Library.Models.UserOrder> GetOrdersByUserID(int userId)
        {
            IQueryable<Entities.UserOrder> orders = from o in _dbContext.UserOrder
                                                    where o.UserId == userId
                                                    select o;
            return orders.Select(Mapper.Map);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
