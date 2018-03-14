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
            Dictionary<String, List<String>> playerTeams = new Dictionary<string, List<string>>();
            try
            {
                String[] lines = File.ReadAllLines(@"..\..\members.txt");
                foreach (String line in lines)
                {
                    String teamName = line.Split(':')[0];
                    String[] playerNames = line.Split(':')[1].Split(',');
                    foreach (String playerName in playerNames)
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
                Console.WriteLine(ex.Message);
            }
            
            foreach (KeyValuePair<String, List<String>> playerTeam in playerTeams)
            {
                String playerName = playerTeam.Key;
                String teamNames = String.Join(", ", playerTeam.Value);
                Console.WriteLine("{0} plays for: {1}", playerName, teamNames);
            }

            Console.ReadLine();
        }
    }
}
