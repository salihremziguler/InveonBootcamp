using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Order
    {

        private int orderId;
        private String customerName;
        private List<String> items;


        public Order(int orderId, String customerName, List<String> items)
        {
            this.orderId = orderId;
            this.customerName = customerName;
            this.items = items;
        }

        public void AddItem(String item)
        {
            items.Add(item);
        }

        public int GetOrderId()
        {
            return orderId;
        }

        public String GetCustomerName()
        {
            return customerName;
        }

        public List<String> GetItems()
        {
            return items;
        }


        //Dış dünya ile iletişim SRP ihlal
        /* public void saveOrderToDatabase()
         {
             Console.WriteLine("Order saved to database");
         }
        */

    }
}
