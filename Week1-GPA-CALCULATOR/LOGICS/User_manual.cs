using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1_GPA_CALCULATOR.UI;

namespace Week1_GPA_CALCULATOR.LOGICS
{
    public static  class User_manual
    {
        public static void Instructions()
        {

            Console.WriteLine("\n+++++++User Manual++++++\n" +

                "Hello Dear\n" +
                "Welcome to GPA Calculator by Obyte\n" +
                "this Manual will guide you on how to use this application\n" +
                "To get started with GPA calculation Kindly follow the instructions and type the exact format the input requires\n" +
                "\nTo get started with the calculation Press the option 2 then follow the instructions\n" +
                "Course code is Alfa-Numeric example MAt101, C#111, Course unit is Positive Intergers only it doesnt take Negative intergers\n" +
                "course score take 0-100, it can not be negative or above 100\n" +
                "Every other thing will be calculated Automatically\n " +
                "\n if you find this from my Github kindly follow me or reach out to me On ocobute@gmail.com\n" +
                "Thanks for using this app\n\n");

             printTable.menuOptions();
        }

    }    
}
