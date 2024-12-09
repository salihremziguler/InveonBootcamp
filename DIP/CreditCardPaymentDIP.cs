using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
   
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
    }



    public class CreditCardPaymentDIP : IPayment
    {
        public void ProcessPayment(decimal amount)
        {

            Console.WriteLine($"Processing credit card payment of {amount} TL ");
        }
    }



    public class PayPalPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {

            Console.WriteLine($" Processing PayPal payment of {amount} TL");
        }
    }



    public class OrderServiceDIP
    {
        private readonly IPayment _payment;

        public OrderServiceDIP(IPayment payment)
        {
            _payment = payment;
        }



        public void CompleteOrder(decimal amount)
        {

            _payment.ProcessPayment(amount);
            Console.WriteLine("Order completed ...");
        }
    }

}
