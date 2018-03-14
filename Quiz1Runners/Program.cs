using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Runners
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Runner> ListRunners = new List<Runner>();
            try
            {
                String[] lines = File.ReadAllLines(@"runners.txt");
                Runner r = new Runner();
                foreach (String line in lines)
                {
                    if (!double.TryParse(line, out double val))
                    {
                        r = new Runner();
                        r.Name = line;
                        ListRunners.Add(r);
                    }
                    else
                    {
                        r.runtimesList.Add(val);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<double> TotalRunTimesList = new List<double>();
            var ListRunnersSortByAvgRunTime = from r in ListRunners orderby AvgTime(r.runtimesList) select r;
            foreach (Runner r in ListRunnersSortByAvgRunTime)
            {
                TotalRunTimesList.AddRange(r.runtimesList);
                
                Console.WriteLine("{0} runs {1} time(s).", r.Name, r.runtimesList.Count);
                Console.WriteLine("{0}'s average is {1:0.00}.", r.Name, AvgTime(r.runtimesList));
            }
            Console.WriteLine("There were {0} runners in total.", ListRunners.Count);
            Console.WriteLine("Average run time for all runners was {0:0.00}", AvgTime(TotalRunTimesList));

            Console.ReadLine();
        }

        static double FastestTime(List<double> list)
        {
            list.Sort();
            return list[0];
        }

        static double AvgTime(List<double> list)
        {
            double sumTime = 0;
            foreach (double time in list)
            {
                sumTime += time;
            }
            return sumTime / list.Count;
        } 
    }

    class Runner
    {
        private String _name;
        private double _avgTime;
        public List<double> runtimesList = new List<double>();

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new InvalidDataException("Name must be between 2 and 20 characters.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public double AvgTime
        {
            get
            {
                return _avgTime;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("Average time must be positive");
                }
                else
                {
                    _avgTime = value;
                }
            }
        }
    }
}
