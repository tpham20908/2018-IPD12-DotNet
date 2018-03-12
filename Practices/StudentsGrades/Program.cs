using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"../../grades.txt");
                foreach (string line in lines)
                {
                    string name = line.Split(':')[0];
                    string[] gpaArr = line.Split(':')[1].Split(',');
                    string gpas = "";
                    foreach (string gpa in gpaArr)
                    {
                        gpas += letterToNumberGrade(gpa) + ", ";
                    }
                    Console.WriteLine("{0} has GPA {1}", name, gpas);
                }

                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        static double letterToNumberGrade(string strGrade)
        {
            double result;
            switch (strGrade)
            {
                case "A":
                    result = 4.00;
                    break;
                case "A-":
                    result = 3.67;
                    break;
                case "B+":
                    result = 3.33;
                    break;
                case "B":
                    result = 3.00;
                    break;
                case "B-":
                    result = 2.67;
                    break;
                case "C+":
                    result = 2.33;
                    break;
                case "C":
                    result = 2.00;
                    break;
                case "C-":
                    result = 1.67;
                    break;
                case "D+":
                    result = 1.33;
                    break;
                case "D":
                    result = 1.00;
                    break;
                case "D-":
                    result = 0.67;
                    break;
                default:
                    result = 0.00;
                    break;
            }
            return result;
        }
    }
}
