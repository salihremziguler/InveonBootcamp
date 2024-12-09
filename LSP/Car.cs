using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{

    //LSP İhlal...
    public class Car
    {
        public virtual void Refuel()
        {
            Console.WriteLine("Refueling the car with gasoline.");
        }
    }


    public class ElectricCar : Car
    {
        public override void Refuel()
        {
            throw new NotImplementedException("Electric cars do not require refueling!");
        }
    }

   
}
