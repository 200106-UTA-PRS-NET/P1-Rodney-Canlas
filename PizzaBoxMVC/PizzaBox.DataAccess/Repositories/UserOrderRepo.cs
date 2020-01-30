﻿using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Library.Interfaces;
using PizzaBox.DataAccess.Entities;

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

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
