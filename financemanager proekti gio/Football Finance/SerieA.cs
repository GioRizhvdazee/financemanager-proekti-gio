
using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class SerieA : Leagues
    {
        List<Team> SerieATeams = new List<Team>
        {
            new Team("Juventus", 10),
            new Team("AC Milan", 10),
            new Team("Inter Milan", 10),
            new Team("AS Roma", 9),
            new Team("Napoli", 10),
            new Team("Lazio", 9),
            new Team("Atalanta", 9),
            new Team("Fiorentina", 8),
            new Team("Torino", 7),
            new Team("Sampdoria", 7),
            new Team("Bologna", 8),
            new Team("Udinese", 7),
            new Team("Sassuolo", 7),
            new Team("Cagliari", 6),
            new Team("Genoa", 7),
            new Team("Hellas Verona", 7),
            new Team("Spezia", 6),
            new Team("Empoli", 6),
            new Team("Salernitana", 6),
            new Team("Monza", 7)
        };

        Random random = new Random();

        public int SerieABudget { get; set; }

        public SerieA() : base("Serie A", 30)
        {
            SerieABudget = random.Next(600, 901) * 1000000;

            foreach (Team team in SerieATeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in SerieATeams)
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
