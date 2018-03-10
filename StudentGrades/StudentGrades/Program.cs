using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            //String text = File.ReadAllText(@"../../../grades.txt");
            //Console.WriteLine(text);

            String[] lines = File.ReadAllLines(@"../../../grades.txt");
            foreach(String line in lines)
            {
                string[] tokens = line.Split(':');
                string name = tokens[0];
                string strGPA = tokens[1];
                string[] arrGPA = strGPA.Split(',');
                string result = "";
                foreach (String gpa in arrGPA)
                {
                    result += letterToNumberGrade(gpa) + " ";
                }
                Console.WriteLine("{0} has GPA {1}", name, result);
            }
            Console.ReadLine();
        }

        static double letterToNumberGrade(string strGrade)
        {
            double grade = 0;
            switch (strGrade)
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
