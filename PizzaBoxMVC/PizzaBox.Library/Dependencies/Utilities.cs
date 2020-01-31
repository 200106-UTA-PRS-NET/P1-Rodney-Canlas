using PizzaBox.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PizzaBox.Library.Dependencies
{
    public static class Utilities
    {
        public static decimal Cost(string size)
        {
            switch (size)
            {
                case "Small":
                    return Convert.ToDecimal(8.00);
                case "Medium":
                    return Convert.ToDecimal(10.00);
                case "Large":
                    return Convert.ToDecimal(12.00);
                default:
                    break;
            }
            return Convert.ToDecimal(0.00);
        }

        public static string ConvertListToString(List<string> list)
        {
            StringBuilder strList = new StringBuilder();
            foreach (string str in list)
            {
                strList.Append(str).Append(" ");
            }

            return strList.ToString();
        }

        /** <summary> Serializes a List object, which holds Pizza objects, into a string. </summary>
         *  <returns> Returns the serialized list of pizzas. </returns>
         */
        public static string SerializeToXMLString(List<Pizza> orderContent)
        {
            using (StringWriter strWriter = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Pizza>));
                serializer.Serialize(strWriter, orderContent);
                return strWriter.ToString();
            }
        }

        /** <summary> Deserializes a string to a List object, which holds Pizza objects. </summary>
         *  <returns> Returns a List object, which holds Pizza objects. </returns>
         */
        public static List<Pizza> DeserializeFromXMLString(string xml)
        {
            var serializer = new XmlSerializer(typeof(List<Pizza>));

            using (TextReader reader = new StringReader(xml))
            {
                return (List<Pizza>)serializer.Deserialize(reader);
            }
        }

        /** <summary> 
         *  Checks if the current user can order from the store
         *      that has a matching ID. 
         *  </summary>
         *  <returns> 
         *  Returns true if the current user has not ordered
         *      from the store within 24 hours; otherwise, returns false.
         *  </returns>
         */
        public static bool CanOrderFromLocation(int userId, IEnumerable<UserOrder> relevantOrders)
        {
            if (relevantOrders.Any(o => o.UserId == userId))
            {
                var ordersByUser = from o in relevantOrders
                                   where o.UserId == userId
                                   select o;

                UserOrder lastOrderByUser = ordersByUser.OrderBy(o => o.OrderDateTime).Last();
                DateTime lastOrderDateTime = lastOrderByUser.OrderDateTime;

                TimeSpan orderGap = DateTime.Now - lastOrderDateTime;

                if (orderGap.TotalDays >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
