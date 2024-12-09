using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
         //OCP' yi ihlal eden kod...
        public class Car
        {
            public string Type { get; set; }

        public void Drive()
        {
            if (Type == "Manual")
            {
                Console.WriteLine("Driving with Manual Transmission ");
            }
            else if (Type == "Automatic")
            {

                Console.WriteLine("Driving with Automatic Transmission ");
            }
        }





    }

}
