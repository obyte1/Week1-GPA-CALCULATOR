using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Week1_GPA_CALCULATOR.LOGICS;


namespace Week1_GPA_CALCULATOR.UI
{
    public static class printTable
    {
        public static void colorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void colorWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void menuOptions()
        {
            Console.WriteLine("\n          PLEASE SELECT AN OPTION TO CONTINUE          \n");
            Console.WriteLine("Press 1 To read instructions");
            Console.WriteLine("Press 2 For GPA calculator");
            Console.WriteLine("Press 3 To Exit\n");

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            string myOptions;

            myOptions = Console.ReadLine();


            switch (myOptions)
            {
                case "1":
                    Console.Clear();
                    User_manual.Instructions();
                    break;

                case "2":
                    Console.Clear();
                    GPA_calc();
                    break;

                case "3":
                    break;

                default:
                    Console.Clear();
                    colorRed();
                    Console.WriteLine("\nPlease enter 1, 2 or 3 to continue:\n");
                    colorWhite();
                    menuOptions();
                    break;
            }
        }
        
        public static void GPA_calc()
        {
            Console.WriteLine("Enter Number of Courses:");
            int size;// = Convert.ToInt32(Console.In.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                colorRed();
                Console.Write("This is not valid input. Please enter an integer value: ");
                colorWhite();
            }

            string[] Course_Code = new string[size];
            int[] Course_unit = new int[size];   //to be summed
            Char[] Grade = new char[size];
            double[] Course_score = new double[size]; //to be summed 
            int[] Grade_Unit = new int[size];
            int[] Weight_pt = new int[size];            
            string[] Remark = new string[size];


            for (int i = 0; i < size; i++)
            {
            Course_Code:
                Console.WriteLine("Enter course Code {0}: ", i + 1);
                Course_Code[i] = Console.ReadLine();
                var validate = new Regex(@"^[A-Za-z]{1,3}[#]?[0-9]{3}$"); 
                
                if (!validate.IsMatch(Course_Code[i]))
                {   colorRed();
                    Console.WriteLine("Type a Valid Course code eg. Mat101, C#111 ");
                    colorWhite();
                    goto Course_Code;                    
                }
            
                Console.WriteLine("Enter Course unit {0}: ", i + 1);                                               
                while (!int.TryParse(Console.ReadLine(), out Course_unit[i]) || Course_unit[i] <= 0 || Course_unit[i] > 10)
                {
                    colorRed();
                    Console.Write("This is not a valid input. Please enter an integer value: ");
                    colorWhite();
                }
                

            Course_score:
                Console.WriteLine("Enter course Score {0}: ", i + 1);
                //Course_score[i] = double.Parse(Console.ReadLine());
                while (!double.TryParse(Console.ReadLine(), out Course_score[i]) || Course_score[i] < 0 || Course_score[i] > 100)
                {
                    colorRed();
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    colorWhite();
                }

                if (Course_score[i] > 100)
                {
                    colorRed();
                    Console.WriteLine("maximum score is 100 ");
                    colorWhite();
                    goto Course_score;
                }
                else
                if (Course_score[i] >= 70 && Course_score[i] <= 100)
                {
                    Grade[i] = 'A';
                    Grade_Unit[i] = 5;
                    Remark[i] = "Excellent";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                if (Course_score[i] >= 60 && Course_score[i] <= 69)
                {
                    Grade[i] = 'B';
                    Grade_Unit[i] = 4;
                    Remark[i] = "Very Good";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                if (Course_score[i] >= 50 && Course_score[i] <= 49)
                {
                    Grade[i] = 'C';
                    Grade_Unit[i] = 3;
                    Remark[i] = "Good";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                 if (Course_score[i] >= 45 && Course_score[i] <= 59)
                {
                    Grade[i] = 'D';
                    Grade_Unit[i] = 2;
                    Remark[i] = "Fair";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                 if (Course_score[i] >= 40 && Course_score[i] <= 44)
                {
                    Grade[i] = 'E';
                    Grade_Unit[i] = 1;
                    Remark[i] = "Pass";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                 if (Course_score[i] >= 0 && Course_score[i] <= 39)
                {
                    Grade[i] = 'F';
                    Grade_Unit[i] = 0;
                    Remark[i] = "Fail";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }

            }
            double ttotal_unitRgt = Course_unit.Sum();
            double totalCourse_score = Course_score.Sum();
            double total_weightpt = Weight_pt.Sum();

            Double GPA = total_weightpt / ttotal_unitRgt;
            GPA = Math.Round(GPA, 2);
            Console.WriteLine("\n");

            var table = new ConsoleTable($"COURSE & CODE", $"COURSE UNIT", $"GRADE", $"GRADE UNIT", $"WEIGHT POINT", $"REMARK");

            for (int i = 0; i < size; i++)
            {
                table.AddRow($"{Course_Code[i].ToUpper()}", $"{Course_unit[i]}" ,$"{Grade[i]}", $"{Grade_Unit[i]}", $"{Weight_pt[i]}",$"{Remark[i]}");
            }
            
            Console.WriteLine(table + "\n");
            Console.WriteLine("Total course unit Registered is:" + ttotal_unitRgt);
            Console.WriteLine("Total weight Piont is:" + total_weightpt );
            Console.WriteLine($"GPA: {GPA}\n\n");


            menuOptions();

        }


    }
}
