using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp
{
    public class UI
    {

        public static void MainMenu()
        {
            Console.WriteLine("Welcome in Timer App!");
            Console.WriteLine("Choose following actions:");

            Console.WriteLine("1.Timer");
            Console.WriteLine("2.Alarm Clock");
            Console.WriteLine("9.Quit");
        }

        public static int Minutnik()
        {
            short value = default;
            bool parseFlag = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Timer");
                Console.WriteLine("choose time to starts from (minutes):");
                string usrInput = Console.ReadLine();

                if (Int16.TryParse(usrInput, out value))
                    return value;

            } while (parseFlag);

            return -1;
        }

        public static DateTime Budzik()
        {
            string inputOne;
            string inputTwo;
            bool parseFlag = true;
            DateTime date = new();

            do
            {
                Console.Clear();

                Console.WriteLine("Alarm Clock:");
                Console.WriteLine("Enter date in format dd/mm/yyyy:");
                inputOne = Console.ReadLine().Trim();
                Console.WriteLine("Enter time in format: hh:mm");
                inputTwo = Console.ReadLine().Trim();

                string dateStringRepr = 
                    string.Concat(inputOne, " " , inputTwo);

                DateTime.TryParse(dateStringRepr, out date);

                if(date != DateTime.MinValue)
                    parseFlag = false;

            } while (parseFlag);

            return date;
        }

        public static void ChoosenAction()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Event has been choosen press enter to execute");
            Console.WriteLine("or any other key to back to menu");
            Console.WriteLine("----------------------------------------");
        }

    }
}
