using System;
using System.Collections.Generic;
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
            Console.WriteLine("Average: " + average(list));
            Console.WriteLine("Max: " + max(list));
            Console.WriteLine("Median: " + median(list));
            Console.WriteLine("Standard Deviation: " + stdDeviation(list));

            Console.ReadLine();
        }

        static double stdDeviation(List<int> list)
        {
            double avg = average(list);
            double sumPowAvg = 0;
            double result;
            foreach (int num in list)
            {
                sumPowAvg += Math.Pow(num - avg, 2);
            }
            result = Math.Sqrt(sumPowAvg / list.Count);
            return result;
        }

        static double median(List<int> list)
        {
            list.Sort();
            if (list.Count % 2 != 0)
            {
                return (double)list[list.Count / 2];
            }
            else
            {
                return (double)(list[list.Count / 2] + list[list.Count / 2 + 1]) / 2;
            }
        }

        static int max(List<int> list)
        {
            list.Sort();
            return list[list.Count - 1];
        }

        static double average(List<int> list)
        {
            double sum = 0;
            foreach (int num in list)
            {
                sum += num;
            }
            return sum / list.Count;
        }

        static void addList(List<int> list)
        {
            while (true)
            {
                Console.WriteLine("Enter a positive number, O to end: ");
                String numStr = Console.ReadLine();
                if (!int.TryParse(numStr, out int value))
                {
                    Console.WriteLine("Not a valid integer, try again");
                    continue;
                }
                if (value <= 0)
                {
                    Console.WriteLine("Done with entering data");
                    break;
                }
                list.Add(value);
            }
            
        }
    }
}
