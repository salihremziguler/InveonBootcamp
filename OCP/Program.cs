using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Car manualCar = new Car { Type = "Manual" };
            manualCar.Drive();

            Car automaticCar = new Car { Type = "Automatic" };
            automaticCar.Drive();


            List<CarOCP> cars = new List<CarOCP>
        {
            new ManualCar(),
            new AutomaticCar(),
            new SemiAutomaticCar()
        };

            foreach (var car in cars)
            {

                car.Drive();
            }
        }
    }
}
