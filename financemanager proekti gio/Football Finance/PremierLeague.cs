
using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class PremierLeague : Leagues
    {
        List<Team> PremierLeagueTeams = new List<Team>
        {
            new Team("Manchester United", 9),
            new Team("Liverpool", 10),
            new Team("Chelsea", 9),
            new Team("Arsenal", 10),
            new Team("Manchester City", 10),
            new Team("Tottenham Hotspur", 9),
            new Team("Leicester City", 8),
            new Team("Everton", 8),
            new Team("West Ham United", 8),
            new Team("Aston Villa", 8),
            new Team("Newcastle United", 9),
            new Team("Southampton", 7),
            new Team("Wolverhampton Wanderers", 8),
            new Team("Crystal Palace", 7),
            new Team("Brighton & Hove Albion", 8),
            new Team("Brentford", 7),
            new Team("Leeds United", 7),
            new Team("Nottingham Forest", 7),
            new Team("Fulham", 7),
            new Team("Bournemouth", 7)
        };

        Random random = new Random();

        public int PremierLeagueBudget { get; set; }

        public PremierLeague() : base("Premier League", 15)
        {
            PremierLeagueBudget = random.Next(700, 1001) * 1000000;
            // am minimums da maximums vaketeb ligis donis mixedvit

            foreach (Team team in PremierLeagueTeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in PremierLeagueTeams)
            {
                if (t.Name == teamName)
                {
                    team = t;
                    break;
                }
            }

            if (team != null)
            {
                Console.WriteLine($"{team.Name} Budget: {team.Budget}");
            }
            else
            {
                Console.WriteLine("Team not found!");
            }
        }
    }
}
