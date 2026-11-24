using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class Bundesliga : Leagues
    {
        List<Team> BundesligaTeams = new List<Team>
        {
            new Team("Bayern Munich", 10),
            new Team("Borussia Dortmund", 10),
            new Team("RB Leipzig", 9),
            new Team("Bayer Leverkusen", 9),
            new Team("Borussia Mönchengladbach", 8),
            new Team("VfL Wolfsburg", 8),
            new Team("Eintracht Frankfurt", 8),
            new Team("1. FC Union Berlin", 8),
            new Team("SC Freiburg", 8),
            new Team("1. FSV Mainz 05", 7),
            new Team("TSG Hoffenheim", 8),
            new Team("VfB Stuttgart", 8),
            new Team("FC Augsburg", 7),
            new Team("1. FC Köln", 7),
            new Team("Arminia Bielefeld", 6),
            new Team("Hertha BSC", 7),
            new Team("Werder Bremen", 7),
            new Team("Schalke 04", 7),
            new Team("Fortuna Düsseldorf", 6),
            new Team("Hamburger SV", 7)
        };

        Random random = new Random();

        public int BundesligaBudget { get; set; }

        public Bundesliga() : base("Bundesliga", 25)
        {
            BundesligaBudget = random.Next(700, 1001) * 1000000;
            Broadcasting = BundesligaBudget * 0.40m;
            Sponsorships = BundesligaBudget * 0.25m;
            RegistrationFees = BundesligaBudget * 0.10m;

            RefereePayments = BundesligaBudget * 0.10m;
            StadiumCosts = BundesligaBudget * 0.10m;
            Prize = BundesligaBudget * 0.05m;

            foreach (Team team in BundesligaTeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in BundesligaTeams)
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
