using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public interface IDrivable
    {
        void Drive();
    }


    public interface IFlyable
    {
        void Fly();
    }

    public interface ISailable
    {
        void Sail();
    }


    public class CarISP : IDrivable
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving...");
        }
    }


    public class AirplaneISP : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Airplane is flying...");
        }
    }


    public class BoatISP : ISailable
    {

        public void Sail()
        {
            Console.WriteLine("Boat is sailing....");
        }
    }
}
