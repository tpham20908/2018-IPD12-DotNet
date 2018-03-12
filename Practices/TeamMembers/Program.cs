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
            try
            {
                string[] lines = File.ReadAllLines(@"../../input.txt");
                Dictionary<string, List<string>> playerTeams = new Dictionary<string, List<string>>();
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
                foreach (KeyValuePair<string, List<string>> playerTeam in playerTeams)
                {
                    string player = playerTeam.Key;
                    string teams = String.Join(", ", playerTeam.Value);
                    Console.WriteLine("{0} plays for {1}", player, teams);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
