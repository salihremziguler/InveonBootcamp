using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Car car = new Car();
            car.Drive();


            CarISP carISP = new CarISP();
            carISP.Drive();

            Airplane airplane = new Airplane();
            //airplane.Drive();  -> ihlal

            AirplaneISP airplaneISP = new AirplaneISP();
            airplaneISP.Fly();

        }
    }
}
