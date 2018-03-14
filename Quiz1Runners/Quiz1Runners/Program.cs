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
            String[] lines = File.ReadAllLines(@"runners.txt");
            //Dictionary<String, List<double>> RunnersRecords = new Dictionary<string, List<double>>();
            List<double> ListTimes = new List<double>();
            List<double> ListTimesEachRunner = new List<double>();
            List<Runner> ListRunners = new List<Runner>();
            Runner r = new Runner();
            int countRunner = 0;
            int countRun = 0;
            Runner runner = new Runner();
            foreach (String line in lines)
            {
                if (!double.TryParse(line, out double val))
                {
                    runner.Name = line;
                    runner.runtimesList = ListTimesEachRunner;
                    if (ListTimesEachRunner.Count != 0)
                    {
                        ListRunners.Add(runner);
                    }
                    runner = new Runner();
                    ListTimesEachRunner = new List<double>();
                    countRunner++;
                }
                else
                {
                    ListTimes.Add(val);
                    ListTimesEachRunner.Add(val);
                }
            }

            foreach (Runner r1 in ListRunners)
            {
                Console.WriteLine("{0} ran {1} time(s)", r1.Name, r1.runtimesList.Count);
                Console.WriteLine("{0}'s average is {1:0.00}", r1.Name, AvgTimeOfAll(r1.runtimesList));
            }
            
            Console.WriteLine("Average run time for all runners was {0}", AvgTimeOfAll(ListTimes));
            Console.WriteLine("The fastest ran was {0}", FastestTime(ListTimes));
            Console.WriteLine("There were {0} runners in total.", countRunner);
            Console.ReadLine();
        }

        static double FastestTime(List<double> list)
        {
            list.Sort();
            return list[0];
        }

        static double AvgTimeOfAll(List<double> list)
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
