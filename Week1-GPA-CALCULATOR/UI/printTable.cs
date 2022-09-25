using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week1_GPA_CALCULATOR.UI
{
    public static class printTable
    {
        internal static void gpaTable()
        {
            
           
                              
        }

        public static void menuOptions()
        {
            Console.WriteLine("WHAT DO YOU WANT TO DO");
            Console.WriteLine("Press 1 To read instructions");
            Console.WriteLine("Press 2 For GPA calculator");
            Console.WriteLine("Press 3 To Exit");

            string myOptions;

            myOptions = Console.ReadLine();

      
            switch (myOptions)
            {
                case "1":
                    Console.Clear();
                    Instructions();
                    break;

                case "2":
                    Console.Clear();
                    GPA_calc();
                    break;

                case "3":
                    break;

                default:                    
                    Console.Clear();
                    Console.WriteLine("Please enter 1, 2 or 3");
                    menuOptions();
                    break;
            }
        }

        public static void Instructions()
        {
            
            Console.WriteLine("User Manual\n" +
                "This is to teach you how to manage this application");
            

            menuOptions();

        }

        public static void GPA_calc()
        {
            Console.WriteLine("Enter Number of Courses:");

            int size;// = Convert.ToInt32(Console.In.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
            }


            string[] Course_Code = new string[size];
            int[] Course_unit = new int[size];   //to be summed
            Char[] Grade = new char[size];
            double[] Course_score = new double[size]; //to be summed 
            int[] Grade_Unit = new int[size];
            int[] Weight_pt = new int[size];
            double[] total_Unit_Rgt = new double[size]; //to be summed
            string[] Remark = new string[size];
            
            
            for (int i = 0; i <size; i++)
            {
                Course_Code:
                Console.WriteLine("Enter course Code {0}: ", i+1);
                Course_Code[i] = Console.In.ReadLine();                          
                var validate = new Regex(@"^[A-Za-z]{1,5}[0-9]{3}$");
                if (!validate.IsMatch(Course_Code[i]))
                {
                    Console.WriteLine("Course code doesn't match");
                    goto Course_Code;
                }

               

                Console.WriteLine("Enter Course unit {0}: ", i + 1);
                //Course_unit[i] = int.Parse(Console.ReadLine());                                
                while (!int.TryParse(Console.ReadLine(), out Course_unit[i]))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                }


                Console.WriteLine("Enter course Score {0}: ", i + 1);
                //Course_score[i] = double.Parse(Console.ReadLine());
                while (!double.TryParse(Console.ReadLine(), out Course_score[i]))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                }


                if (Course_score[i] >= 70 && Course_score[i] <= 100)
                {
                    Grade[i] = 'A';
                    Grade_Unit[i] = 5;
                    Remark[i] = "Excellent";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else 
                if(Course_score[i] >= 60)
                {
                    Grade[i] = 'B';
                    Grade_Unit[i] = 4;
                    Remark[i] = "Very Good";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }else
                if(Course_score[i] >= 50)
                {
                    Grade[i] = 'C';
                    Grade_Unit[i] = 3;
                    Remark[i] = "Good";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }else
                 if (Course_score[i] >= 45)
                {
                    Grade[i] = 'D';
                    Grade_Unit[i] = 2;
                    Remark[i] = "Fair";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }else
                 if (Course_score[i] >= 40)
                {
                    Grade[i] = 'E';
                    Grade_Unit[i] = 1;
                    Remark[i] = "Pass";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }else
                if (Course_score[i] <= 39)
                  {
                    Grade[i] = 'F';
                    Grade_Unit[i] = 0;
                    Remark[i] = "Fail";
                    Weight_pt[i] = Course_unit[i] * Grade_Unit[i];
                }
                else
                {
                    Console.WriteLine(" maximum score is 100");
                }

                

            }
            
            double ttotal_unitRgt = Course_unit.Sum();
            double totalCourse_score = Course_score.Sum();
            double total_weightpt = Weight_pt.Sum();

            Double GPA = total_weightpt / ttotal_unitRgt;
            GPA = Math.Round(GPA, 2);


            Console.WriteLine(" \n\n |----------------|--------------|----------|------------|-----------|----------------|\n " +
                                   " | COURSE & CODE  | COURSE UNIT  | GRADE    | GRADE-UNIT | WEIGHT PT | REMARK         |\n" +
                                   " |----------------|--------------|----------|------------|-----------|----------------|\n");
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine($"   {Course_Code[i]}        | {Course_unit[i]}            |      { Grade[i]}    |       { Grade_Unit[i] }   |   { Weight_pt[i]}      |  { Remark[i]}");
            }
            Console.WriteLine("  |----------------|--------------|----------|------------|-----------|----------------|\n");


            Console.WriteLine($"GPA: {GPA}");

            Console.WriteLine("welcome to GPA Calculator");
            menuOptions();

        }

        
    }
}
