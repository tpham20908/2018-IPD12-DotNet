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
                string[] lines = File.ReadAllLines(@"../../../grades.txt");
                foreach (string line in lines)
                {
                    string name = line.Split(':')[0];
                    string strGpa = line.Split(':')[1];
                    string[] arrGpa = strGpa.Split(',');
                    string result = "";
                    foreach (string gpa in arrGpa)
                    {
                        result += letterToNumberGrade(gpa) + " ";
                    }
                    Console.WriteLine("{0} has GPA {1}", name, result);
                }
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error finding file: " + ex.Message);
            }
            
        }

        static double letterToNumberGrade (string letter)
        {
            double grade = 0;
            switch (letter)
            {
                case "A":
                    grade = 4.00;
                    break;
                case "A-":
                    grade = 3.67;
                    break;
                case "B+":
                    grade = 3.33;
                    break;
                case "B":
                    grade = 3.00;
                    break;
                case "B-":
                    grade = 2.67;
                    break;
                case "C+":
                    grade = 2.33;
                    break;
                case "C":
                    grade = 2.00;
                    break;
                case "C-":
                    grade = 1.67;
                    break;
                case "D+":
                    grade = 1.33;
                    break;
                case "D":
                    grade = 1.00;
                    break;
                case "D-":
                    grade = 0.67;
                    break;
                case "F":
                    grade = 0.00;
                    break;
            }
            return grade;
        }
    }
}
