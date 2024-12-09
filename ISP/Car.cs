using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    //ISP ihlal....
    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Sail();

    }




    public class Car : IVehicle
    {
        public void Drive()
        {

            Console.WriteLine("Car is driving...");
        }

        public void Fly()
        {
            throw new NotImplementedException("Cars cannot fly...");
        }

        public void Sail()
        {

            throw new NotImplementedException("Cars cannot sail...");
        }
    }



    public class Airplane : IVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException("Airplanes cannot drive on roads..");
        }

        public void Fly()
        {
            Console.WriteLine("Airplane is flying.");
        }

        public void Sail()
        {
            throw new NotImplementedException("Airplanes cannot sail...");
        }
    }



    public class Boat : IVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException("Boats cannot drive...");
        }

        public void Fly()
        {
            throw new NotImplementedException("Boats cannot fly...");
        }


        public void Sail()
        {
            Console.WriteLine("Boat is sailing.");
        }
    }
}
