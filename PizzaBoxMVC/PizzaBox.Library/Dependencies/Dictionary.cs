using PizzaBox.Library.Models;
using System.Collections.Generic;

namespace PizzaBox.Library.Dependencies
{
    public static class Dictionary
    {
        public static Dictionary<int, string> StoreDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "Giant Caesars"},
                { 2, "Mama Johns"},
                { 3, "Pizza Igloo"}
            };
        }

        public static Dictionary<int, string> AccountDictionary(IEnumerable<Account> accounts)
        {
            Dictionary<int, string> userIdToFullName = new Dictionary<int, string>();
            
            foreach (Account account in accounts)
            {
                userIdToFullName.Add(account.Id, $"{account.FirstName} {account.LastName}");
            }

            return userIdToFullName;
        }
    }
}
