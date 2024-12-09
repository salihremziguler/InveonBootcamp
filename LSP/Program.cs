using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car(),
                // new ElectricCar()  // Error... ihlall

            };



            foreach (var car in cars)
            {
                car.Refuel();
            }



            List<Car_LSP> _cars = new List<Car_LSP>
             {
            new FuelCar(),
            new ElectricCar_LSP()
            };


            foreach (var car in _cars)
            {
                car.Drive();
            }

            FuelCar fuelCar = new FuelCar();
            fuelCar.Refuel();

            ElectricCar_LSP electricCar = new ElectricCar_LSP();
            electricCar.Recharge();




        }
    }
}
