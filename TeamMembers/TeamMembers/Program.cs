using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> playerTeams = new Dictionary<string, List<string>>();

            try
            {
                string[] lines = File.ReadAllLines(@"../../../input.txt");
                foreach (string line in lines)
                {
                    string teamName = line.Split(':')[0];
                    string[] playersName = line.Split(':')[1].Split(',');
                    foreach (string playerName in playersName)
                    {
                        if (!playerTeams.ContainsKey(playerName))
                        {
                            playerTeams.Add(playerName, new List<string>());
                        }
                        playerTeams[playerName].Add(teamName);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File Not Found Error: " + ex.Message);
            }

            foreach (KeyValuePair<string, List<string>> playerTeam in playerTeams)
            {
                string teamName = "";
                foreach (string team in playerTeam.Value)
                {
                    teamName += team + ", ";
                }
                Console.WriteLine("{0} plays for {1}", playerTeam.Key, teamName);
            }
            
            Console.ReadLine();
        }
    }
}
