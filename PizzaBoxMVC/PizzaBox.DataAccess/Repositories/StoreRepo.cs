using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Library.Interfaces;
using PizzaBox.DataAccess.Entities;
using System.Linq;

namespace PizzaBox.DataAccess.Repositories
{
    public class StoreRepo : IStoreRepo
    {
        private readonly PizzaBoxDbContext _dbContext;

        public StoreRepo(PizzaBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Library.Models.Store> GetStores()
        {
            IQueryable<Entities.Store> stores = from s in _dbContext.Store select s;

            return stores.Select(Mapper.Map);
        }

        public Library.Models.Store GetStoreByID(int id)
        {
            IQueryable<Entities.Store> stores = from s in _dbContext.Store
                                                where s.Id == id
                                                select s;

            return stores.Select(Mapper.Map).FirstOrDefault();
        }

    }
}
