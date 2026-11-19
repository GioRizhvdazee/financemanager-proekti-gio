
using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class Ligue1 : Leagues
    {
        List<Team> Ligue1Teams = new List<Team>
        {
            new Team("Paris Saint-Germain", 10),
            new Team("Olympique de Marseille", 9),
            new Team("AS Monaco", 9),
            new Team("Lille OSC", 9),
            new Team("Olympique Lyonnais", 9),
            new Team("Stade Rennais", 8),
            new Team("OGC Nice", 8),
            new Team("Montpellier HSC", 7),
            new Team("RC Lens", 8),
            new Team("FC Nantes", 7),
            new Team("Stade Brestois 29", 7),
            new Team("Angers SCO", 6),
            new Team("FC Metz", 6),
            new Team("Clermont Foot 63", 6),
            new Team("Toulouse FC", 7),
            new Team("ESTAC Troyes", 6),
            new Team("FC Lorient", 7),
            new Team("Stade de Reims", 7),
            new Team("RC Strasbourg Alsace", 7),
            new Team("FC Girondins de Bordeaux", 6)
        };

        Random random = new Random();

        public int Ligue1Budget { get; set; }

        public Ligue1() : base("Ligue 1", 40)
        {
            Ligue1Budget = random.Next(600, 901) * 1000000;

            foreach (Team team in Ligue1Teams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in Ligue1Teams)
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
