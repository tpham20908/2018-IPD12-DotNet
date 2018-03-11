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
                    string team = line.Split(':')[0];
                    string[] players = line.Split(':')[1].Split(',');
                    foreach (string player in players)
                    {
                        if (!playerTeams.ContainsKey(player))
                        {
                            playerTeams.Add(player, new List<string>());
                        }
                        playerTeams[player].Add(team);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found error: " + ex.Message);
            }

            foreach (KeyValuePair<string, List<string>> playerTeam in playerTeams)
            {
                string player = playerTeam.Key;
                string teams = "";
                foreach (string team in playerTeam.Value)
                {
                    teams += team + ", ";
                }
                Console.WriteLine("{0} plays for {1}", player, teams);
            }

            /*
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
            */
            Console.ReadLine();
        }
    }
}
