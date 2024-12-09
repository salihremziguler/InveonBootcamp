using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ihlal
            OrderService orderService = new OrderService();
            orderService.CompleteOrder(100.0m);





            IPayment creditCardPayment = new CreditCardPaymentDIP();
            OrderServiceDIP orderService1 = new OrderServiceDIP(creditCardPayment);
            orderService1.CompleteOrder(100.0m);

            IPayment payPalPayment = new PayPalPayment();
            OrderServiceDIP orderService2 = new OrderServiceDIP(payPalPayment);
            orderService2.CompleteOrder(200.0m);

        }
    }
}
