using System.Collections.Generic;
using System.Text;

namespace DAY_25._2
{   
    class Player 
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool  IsOut { get; set; } 
        public double  StrikeRate { get; set; }
        public  double Average { get; set; }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"../../../players.csv"); 
           

            List<Player> player = new List<Player>();
                List<string> lessPlayed = new List<string>();

            string line = string.Empty;
                while((line = sr.ReadLine()) != null )
                {
                    string[] arr = line.Split(",");

                    string name = arr[0];
                    int runs = int.Parse(arr[1]);
                    int balls = int.Parse(arr[2]);
                    bool outt = bool.Parse(arr[3]);
                    if(balls < 10) lessPlayed.Add(name);

                    player.Add(new Player()
                    {
                        Name = name,
                        RunsScored = runs,
                        BallsFaced = balls,
                        IsOut = outt,
                        StrikeRate = balls != 0 ? (double)runs / balls * 100 : 0,
                        Average = (double)runs / 5

                    });

                }
                player.Sort((p1,p2) => p2.StrikeRate.CompareTo(p1.StrikeRate));

                Console.WriteLine($"{"NAME",-15}|{"RUNS",-15}|{"SR",-15}|{"AVG",-15}");
                foreach (Player p in player)
                {
                    Console.WriteLine($"{p.Name,-15}|{p.RunsScored,-15}|{p.StrikeRate,-15:F2}|{p.Average,-15}");
                }

            
        }
    }
}
