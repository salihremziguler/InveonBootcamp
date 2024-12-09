using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class Orderrepository
    {
        public void saveOrder(Order order)
        {
            // Veritabanına kaydetme işlemleri
            Console.WriteLine("Order with ID " + order.GetOrderId() + " saved to database");
        }
    }
}
