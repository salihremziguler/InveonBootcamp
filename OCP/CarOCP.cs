using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public abstract class CarOCP
    {
        public abstract void Drive();
    }


    public class ManualCar : CarOCP
    {
        public override void Drive()
        {
            Console.WriteLine("Driving with Manual Transmission...");
        }
    }

    public class AutomaticCar :  CarOCP
    {
        public override void Drive()
        {
            Console.WriteLine("Driving with Automatic Transmission...");
        }
    }



    public class SemiAutomaticCar :  CarOCP
    {
        public override void Drive()
        {
            Console.WriteLine("Driving with Semi Automatic Transmission...");
        }
    }


}
