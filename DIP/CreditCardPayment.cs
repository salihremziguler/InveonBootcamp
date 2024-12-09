using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    //DIP ihlal...

    //Düşük seviyeli 
    public class CreditCardPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($" Processing credit card payment of  {amount} TL ");
        }
    }




    //Yüksek seviyeli
    public class OrderService
    {
        private CreditCardPayment _payment;

        public OrderService()
        {
            _payment = new CreditCardPayment();
        }

        public void CompleteOrder(decimal amount)
        {

            _payment.ProcessPayment(amount);

            Console.WriteLine("Order completed...");
        }
    }
}
