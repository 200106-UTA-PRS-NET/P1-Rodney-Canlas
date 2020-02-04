namespace PizzaBox.DataAccess
{
    public static class Mapper
    {
        public static Entities.Account Map(Library.Models.Account account)
        {
            return new Entities.Account
            {
                Id = account.Id,
                Username = account.Username,
                Passphrase = account.Passphrase,
                FirstName = account.FirstName,
                LastName = account.LastName
            };
        }

        public static Library.Models.Account Map(Entities.Account account)
        {
            return new Library.Models.Account
            {
                Id = account.Id,
                Username = account.Username,
                Passphrase = account.Passphrase,
                FirstName = account.FirstName,
                LastName = account.LastName
            };
        }

        public static Entities.Store Map(Library.Models.Store store)
        {
            return new Entities.Store
            {
                Id = store.Id,
                StoreName = store.StoreName,
                City = store.City,
                State = store.State,
                Zipcode = store.Zipcode
            };
        }

        public static Library.Models.Store Map(Entities.Store store)
        {
            return new Library.Models.Store
            {
                Id = store.Id,
                StoreName = store.StoreName,
                City = store.City,
                State = store.State,
                Zipcode = store.Zipcode
            };
        }

        public static Entities.UserOrder Map(Library.Models.UserOrder userOrder)
        {
            return new Entities.UserOrder
            {
                Id = userOrder.Id,
                StoreId = userOrder.StoreId,
                UserId = userOrder.UserId,
                OrderContent = userOrder.OrderContent,
                TotalCost = userOrder.TotalCost,
                OrderDateTime = userOrder.OrderDateTime
            };
        }

        public static Library.Models.UserOrder Map(Entities.UserOrder userOrder)
        {
            return new Library.Models.UserOrder
            {
                Id = userOrder.Id,
                StoreId = userOrder.StoreId,
                UserId = userOrder.UserId,
                OrderContent = userOrder.OrderContent,
                TotalCost = userOrder.TotalCost,
                OrderDateTime = userOrder.OrderDateTime
            };
        }
    }
}
