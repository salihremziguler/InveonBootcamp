using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
  

        public abstract class Car_LSP
    {
            public abstract void Drive();
        }


        public class FuelCar : Car_LSP
    {
            public override void Drive()
            {
                Console.WriteLine("Driving a fuel-powered car.");
            }

            public void Refuel()
            {
                Console.WriteLine("Refueling the car with gasoline.");
            }
        }




        public class ElectricCar_LSP : Car_LSP
    {
            public override void Drive()
            {
                Console.WriteLine("Driving an electric car.");
            }

            public void Recharge()
            {
                Console.WriteLine("Recharging the electric car.");
            }
        }
    }

