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
            Console.ForegroundColor = ConsoleColor.White;
            

            Console.WriteLine("\n\n ********************************** WELCOME TO WEEK ONE TASK **********************************\n");
        }     
    }
}
