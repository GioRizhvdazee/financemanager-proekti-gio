// Football League 
// Airline 
// Film Studio
// Real Estate
// Shipping Company
// Luxury Fashion Brand
// Formula Racing
using financemanager_proekti_gio.Football_Finance;

namespace financemanager_proekti_gio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Congratulations! We Saw That You Had Experience In Running A Part Of Big Companies.");
            Console.WriteLine("Your Role Was Being A Finance Manager. We Have A Couple Of Offers For You:");

            Console.WriteLine();

            Console.WriteLine("Available Positions:");
            Console.WriteLine("0. Football League");
            Console.WriteLine("1. Airline");
            Console.WriteLine("2. Film Studio");
            Console.WriteLine("3. Real Estate");
            Console.WriteLine("4. Shipping Company");
            Console.WriteLine("5. Luxury Fashion Brand");
            Console.WriteLine("6. Formula Racing");

            Console.WriteLine();
            Console.WriteLine("Please Choose Your Position:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Available Football Leagues:");

                    List<Leagues> leagues = new List<Leagues>
                    {
                        new PremierLeague(),
                        new LaLiga(),
                        new Bundesliga(),
                        new SerieA(),
                        new Ligue1(),
                        new Eredivisie(),
                        new PrimeiraLiga()
                    };

                    for (int ligebi = 0; ligebi < leagues.Count; ligebi++)
                    {
                        Console.WriteLine($"{ligebi}. {leagues[ligebi].Name}");
                    }

                    Console.WriteLine("Choose A League:");

                    int leagueChoice = Convert.ToInt32(Console.ReadLine());

                    if (leagueChoice >= 0 && leagueChoice < leagues.Count)
                    {
                        Leagues selectedLeague = leagues[leagueChoice];

                        bool accepted = selectedLeague.Apply();

                        if (!accepted)
                        {
                            return;
                        }

                        bool running = true;

                        while (running)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Available Methods:");
                            Console.WriteLine("1. Check Team Budget");
                            Console.WriteLine("2. Exit");

                            Console.WriteLine("Choose A Method:");

                            int method = Convert.ToInt32(Console.ReadLine());

                            switch (method)
                            {
                                case 1:
                                    Console.WriteLine("Enter Team Name:");
                                    string teamName = Console.ReadLine();

                                    selectedLeague.ShowTeamBudget(teamName);
                                    break;

                                case 2:
                                    running = false;
                                    Console.WriteLine("Goodbye!");
                                    break;

                                default:
                                    Console.WriteLine("Invalid Choice!");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid League Choice!");
                    }

                    break;

                case 1:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of An Airline Company!");
                    break;

                case 2:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Film Studio!");
                    break;

                case 3:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Real Estate Company!");
                    break;

                case 4:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Shipping Company!");
                    break;

                case 5:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Luxury Fashion Brand!");
                    break;

                case 6:
                    Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Formula Racing Team!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice! Please Select A Number Between 0 And 6.");
                    break;
            }
        }
    }
}