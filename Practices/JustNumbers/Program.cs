using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            addList(list);
            
            Console.WriteLine("Average of all number is " + average(list));
            Console.WriteLine("Maximum: " + max(list));
            Console.WriteLine("Median: " + median(list));
            Console.WriteLine("Standard deviation: " + stdDeviation(list));
            writing(list);

            Console.ReadLine();
        }

        static void writing(List<int> list)
        {
            string line = string.Join(";", list);
            File.WriteAllText("../../../output.txt", line);
        }

        static double stdDeviation(List<int> list)
        {
            double med = median(list);
            double sum = 0;
            foreach (int num in list)
            {
                sum += Math.Pow((num - med), 2);
            }
            return Math.Sqrt(sum / list.Count);
        }

        static double median(List<int> list)
        {
            list.Sort();
            if (list.Count % 2 == 1)
            {
                return list[list.Count / 2];
            }
            else
            {
                return (list[list.Count / 2] + list[list.Count / 2 + 1]) / 2.0;
            }
        }

        static int max(List<int> list)
        {
            list.Sort();
            return list[list.Count - 1];
        }

        static void addList(List<int> list)
        {
            while (true)
            {
                Console.WriteLine("Enter a positive number, 0 to end: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Not a valid integer, try again.");
                    continue;
                }
                if (value <= 0)
                {
                    Console.WriteLine("Done with entering data");
                    break;
                }
                list.Add(value);
            }
            Console.Write("List of integer: {");
            foreach (int num in list)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine("}");
            list.Sort();
            Console.Write("Sorted list: {");
            foreach (int num in list)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine("}");
        }

        static double average(List<int> list)
        {
            double sum = 0.0;
            foreach (int num in list)
            {
                sum += num;
            }
            return sum / list.Count;
        }
    }
}
