using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_GPA_CALCULATOR.UI
{
    public static class Welcome_msg
    {
        internal static void welcome()
        {
            Console.Clear();
            //Title of my App
            Console.Title = "DECAGON GPA CALC";

            //Text color
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("\n\n ********************************** WELCOME TO WEEK ONE TASK **********************************\n");






        }

        internal static void pressEnterToContinue()
        {
            Console.WriteLine("\n\nPress enter to continue\n");
            Console.ReadLine();
        }

        //public static void centrilize()
        //{
        //    string textTocenter = "44";
        //    Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (textTocenter.Length / 2)) + "}", textTocenter));
        //    Console.ReadLine();
        //}


    }
}
