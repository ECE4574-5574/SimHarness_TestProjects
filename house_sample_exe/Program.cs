using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_sample_exe
{
    class Program
    {

        /* This program is a dummy representation of the house.exe program */

        static void Main(string[] args) {

            //receive initial instruction
            Console.WriteLine("printing command line arguments received:");
            foreach (string s in args) {
                Console.WriteLine(s);
            }

            /* for devices only
            //entering idle mode, waiting for 'GO' signal
            Console.WriteLine("Waiting for timeframe information...");
            string message = Console.ReadLine();
            Console.Write("Message received: ");
            Console.WriteLine(message);
             * */

            while (true) ;
        }
    }
}
