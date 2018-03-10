using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            AddList(list);
            WriteText(list);
            
            Console.WriteLine("Average is: {0}", Avg(list));
            Console.WriteLine("Maximum number is: " + Max(list));
            Console.WriteLine("Median of the list: " + Median(list));
            Console.WriteLine("Standard Deviation: " + StdDeviation(list));

            Console.ReadLine();
        }

        // write numbers to file, semicolon-seperated
        static void WriteText(List<int> list)
        {
            String line = String.Join(";", list);
            File.WriteAllText("output.txt", line);

            /*
            TextWriter tw = new StreamWriter("../../output.txt");
            foreach (int item in list)
            {
                tw.WriteLine("{0};", item);
            }
            tw.Close();
            */
        }

        static void AddList(List<int> list)
        {
            while (true)
            {
                Console.WriteLine("Please enter a positive integer, 0 to end: ");
                String line = Console.ReadLine();
                
                if (!int.TryParse(line, out int value)) 
                {
                    Console.WriteLine("Wrong data type input.");
                    continue;
                }

                if (value <= 0)
                {
                    Console.WriteLine("Done with entering data.");
                    break;
                }

                list.Add(value);
            } 
        } 

        static double StdDeviation(List<int> list)
        {
            double sum = 0;
            foreach (int num in list)
            {
                sum += Math.Pow(num - Avg(list), 2);
            }
            double result = Math.Sqrt(sum / list.Count);
            return result;
        }

        static double Avg(List<int> list)
        {
            int total = 0;
            foreach (int item in list)
            {
                total += item;
            }
            double avg = total * 1.0 / (list.Count - 1);
            return avg;
        }

        static int Max(List<int> list)
        {
            int max = list[0];
            foreach (int item in list)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        static double Median(List<int> list)
        {
            double median = 0.0;
            if (list.Count % 2 == 1)
            {
                median = list[list.Count / 2];
            }
            else
            {
                median = (list[list.Count / 2 - 1] + list[list.Count / 2]) / 2.0;
            }
            return median;
        }
    }
}
