using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrages
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"..\..\grades.txt");
                foreach (string line in lines)
                {
                    String name = line.Split(':')[0];
                    String[] gradesArr = line.Split(':')[1].Split(',');
                    try
                    {
                        double sumGrade = 0, avgGrade;
                        foreach (String gradeStr in gradesArr)
                        {
                            sumGrade += letterToNumberGrade(gradeStr);
                        }
                        avgGrade = sumGrade / gradesArr.Length;
                        Console.WriteLine("{0}'s GPA is {1:0.00}", name, avgGrade);
                    }
                    catch (InvalidDataException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
            

            
            Console.ReadLine();
        }

        static double letterToNumberGrade(String strGrade)
        {
            switch (strGrade)
            {
                case "A+": return 4.33;
                case "A": return 4.00;
                case "A-": return 3.67;
                case "B+": return 3.33;
                case "B": return 3.00;
                case "B-": return 2.67;
                case "C+": return 2.33;
                case "C": return 2.00;
                case "C-": return 1.67;
                case "D+": return 1.33;
                case "D": return 1.00;
                case "D-": return 0.67;
                case "F": return 0.00;
                default:
                    throw new InvalidDataException("Unknown letter grade " + strGrade);
            }
        }
    }
}
