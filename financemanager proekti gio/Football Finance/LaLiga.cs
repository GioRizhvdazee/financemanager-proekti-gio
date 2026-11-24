
using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class LaLiga : Leagues
    {
        List<Team> LaLigaTeams = new List<Team>
        {
            new Team("Barcelona", 10),
            // barca pirvelze abara
            new Team("Real Madrid", 10),
            new Team("Atletico Madrid", 10),
            new Team("Sevilla", 8),
            new Team("Valencia", 8),
            new Team("Villarreal", 9),
            new Team("Real Sociedad", 9),
            new Team("Athletic Bilbao", 9),
            new Team("Celta Vigo", 7),
            new Team("Espanyol", 7),
            new Team("Getafe", 7),
            new Team("Real Betis", 8),
            new Team("Granada", 6),
            new Team("Levante", 6),
            new Team("Alaves", 6),
            new Team("Osasuna", 7),
            new Team("Mallorca", 7),
            new Team("Rayo Vallecano", 7),
            new Team("Elche", 6)
        };

        Random random = new Random();

        public int LaLigaBudget { get; set; }

        public LaLiga() : base("LaLiga", 20)
        {
            LaLigaBudget = random.Next(700, 1001) * 1000000;
            // igivea chemtvis premier leauge da la liga donis mixedvit
            Broadcasting = LaLigaBudget * 0.40m;
            Sponsorships = LaLigaBudget * 0.25m;
            RegistrationFees = LaLigaBudget * 0.10m;

            RefereePayments = LaLigaBudget * 0.10m;
            StadiumCosts = LaLigaBudget * 0.10m;
            Prize = LaLigaBudget * 0.05m;
            foreach (Team team in LaLigaTeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in LaLigaTeams)
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
