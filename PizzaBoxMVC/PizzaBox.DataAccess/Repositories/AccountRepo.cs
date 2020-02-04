using System.Collections.Generic;
using PizzaBox.Library.Interfaces;
using PizzaBox.DataAccess.Entities;
using System.Linq;

namespace PizzaBox.DataAccess.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly PizzaBoxDbContext _dbContext;

        public AccountRepo(PizzaBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAccount(Library.Models.Account account)
        {
            Entities.Account newAccount = Mapper.Map(account);
            _dbContext.Add(newAccount);
        }

        public IEnumerable<Library.Models.Account> GetAccounts()
        {
            IQueryable<Entities.Account> accounts = from u in _dbContext.Account
                                           select u;
            return accounts.Select(Mapper.Map);
        }

        public IEnumerable<Library.Models.Account> GetAccountsByUsername(string username)
        {
            IQueryable<Entities.Account> accounts = from u in _dbContext.Account
                                                    where u.Username == username
                                                    select u;
            return accounts.Select(Mapper.Map);
        }

        public Library.Models.Account GetUserByUserID(int userId)
        {
            IQueryable<Entities.Account> accounts = from u in _dbContext.Account
                                                    where u.Id == userId
                                                    select u;

            return accounts.Select(Mapper.Map).FirstOrDefault();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
