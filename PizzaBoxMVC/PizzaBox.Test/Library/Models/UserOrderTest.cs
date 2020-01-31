using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaBox.Test.Library.Models
{
    public class UserOrderTest
    {
        private readonly UserOrder _order = new UserOrder();

        [Fact]
        public void UserId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _order.Id = randomIntValue;
            Assert.Equal(randomIntValue, _order.Id);
        }

        [Fact]
        public void OrderContent_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "manypizzas";
            _order.OrderContent = randomStringValue;
            Assert.Equal(randomStringValue, _order.OrderContent);
        }

        [Fact]
        public void TotalCost_NonEmptyValue_StoresCorrectly()
        {
            decimal randomDecimalValue = 1;
            _order.TotalCost = randomDecimalValue;
            Assert.Equal(randomDecimalValue, _order.TotalCost);
        }

    }
}
