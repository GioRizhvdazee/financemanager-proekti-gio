
namespace financemanager_proekti_gio.Football_Finance
{
    internal class Eredivisie : Leagues
    {
        List<Team> EredivisieTeams = new List<Team>
        {
            new Team("Ajax", 10),
            new Team("PSV Eindhoven", 10),
            new Team("Feyenoord", 10),
            new Team("AZ Alkmaar", 9),
            new Team("Vitesse", 7),
            new Team("FC Utrecht", 8),
            new Team("SC Heerenveen", 7),
            new Team("FC Groningen", 7),
            new Team("Sparta Rotterdam", 7),
            new Team("FC Twente", 8),
            new Team("ADO Den Haag", 6),
            new Team("Willem II", 6),
            new Team("PEC Zwolle", 6),
            new Team("Fortuna Sittard", 6),
            new Team("RKC Waalwijk", 5),
            new Team("Heracles Almelo", 6),
            new Team("VVV-Venlo", 5)
        };

        Random random = new Random();

        public int EredivisieBudget { get; set; }

        public Eredivisie() : base("Eredivisie", 55)
        {
            EredivisieBudget = random.Next(250, 451) * 1000000;

            foreach (Team team in EredivisieTeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in EredivisieTeams)
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
