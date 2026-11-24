
namespace financemanager_proekti_gio.Football_Finance
{
    internal class PrimeiraLiga : Leagues
    {
        Random random = new Random();

        public int PrimeiraLigaBudget { get; set; }

        public List<Team> PrimeiraLigaTeams = new List<Team>
        {
            new Team("Benfica", 10),
            new Team("Porto", 10),
            new Team("Sporting CP", 10),
            new Team("Braga", 9),
            new Team("Vitória de Guimarães", 8),
            new Team("Marítimo", 6),
            new Team("Boavista", 6),
            new Team("Santa Clara", 6),
            new Team("Gil Vicente", 7),
            new Team("Paços de Ferreira", 5),
            new Team("Tondela", 5),
            new Team("Famalicão", 7),
            new Team("Moreirense", 6),
            new Team("Portimonense", 5),
            new Team("Belenenses SAD", 5),
            new Team("Nacional", 5),
            new Team("Estoril Praia", 6),
            new Team("Casa Pia", 7),
            new Team("Chaves", 5),
            new Team("Arouca", 7)
        };

        public PrimeiraLiga() : base("Primeira Liga", 70)
        {
            PrimeiraLigaBudget = random.Next(200, 351) * 1000000;
            Broadcasting = PrimeiraLigaBudget * 0.40m;
            Sponsorships = PrimeiraLigaBudget * 0.25m;
            RegistrationFees = PrimeiraLigaBudget * 0.10m;

            RefereePayments = PrimeiraLigaBudget * 0.10m;
            StadiumCosts = PrimeiraLigaBudget * 0.10m;
            Prize = PrimeiraLigaBudget * 0.05m;

            foreach (Team team in PrimeiraLigaTeams)
            {
                int minBudget = team.Level * 5000000;
                int maxBudget = team.Level * 10000000;

                team.Budget = random.Next(minBudget, maxBudget + 1);
            }
        }

        public override void ShowTeamBudget(string teamName)
        {
            Team? team = null;

            foreach (Team t in PrimeiraLigaTeams)
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
