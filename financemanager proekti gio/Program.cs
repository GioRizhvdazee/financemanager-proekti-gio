
// Football League 
// Airline 
// Film Studio
// Real Estate
// Shipping Company
// Luxury Fashion Brand
// Formula Racing
using financemanager_proekti_gio;
using financemanager_proekti_gio.FinanceManagerOfAFilmStudio;
using financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder;
using financemanager_proekti_gio.FinanceManagerOfARealEstateCompany;
using financemanager_proekti_gio.Football_Finance;
using static financemanager_proekti_gio.FinanceManager;

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
                Console.WriteLine("2. Calculate Leauge Profit");
                Console.WriteLine("3. Exit");

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
                        selectedLeague.CalculateLeaugeProfit();
                        break;

                    case 3:
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

        FinanceManagerOfAnAirlineCompany finance = new();

        finance.AddRevenue(new RevenueOfAnAirlineCompany
        {
            Id = 1,
            FlightId = 101,
            Amount = 500,
            Date = DateTime.Now
        });

        finance.AddExpense(new ExpenseOfAnAirlineCompany
        {
            Id = 1,
            Type = "Fuel",
            Description = "Flight fuel",
            Amount = 150,
            Date = DateTime.Now
        });

        finance.AddRefund(new RefundOfAnAirlineCompany
        {
            Id = 1,
            BookingId = 20,
            Amount = 50,
            Date = DateTime.Now
        });

        FinancialReportOfAnAirlineCompany report = finance.GenerateReport();

        Console.WriteLine($"Revenue: ${report.TotalRevenue}");
        Console.WriteLine($"Expenses: ${report.TotalExpenses}");
        Console.WriteLine($"Refunds: ${report.TotalRefunds}");
        Console.WriteLine($"Net Profit: ${report.NetProfit}");
        // dzlivs done

        break;

    case 2:
        Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Film Studio!");

        FinanceManagerOfAFilmStudio filmStudio = new();

        bool mabmbambamba = true;

        while (mabmbambamba)
        {
            Console.WriteLine();
            Console.WriteLine("Available Methods:");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Add Revenue");
            Console.WriteLine("3. Add Expense");
            Console.WriteLine("4. Show Movie Profit");
            Console.WriteLine("5. Show Most Profitable Movie");
            Console.WriteLine("6. Exit");

            Console.WriteLine("Choose A Method:");

            int filmMethod = Convert.ToInt32(Console.ReadLine());

            switch (filmMethod)
            {
                case 1:
                    filmStudio.AddMovie();
                    break;

                case 2:
                    filmStudio.AddRevenue();
                    break;

                case 3:
                    filmStudio.AddExpense();
                    break;

                case 4:
                    filmStudio.ShowMovieProfit();
                    break;

                case 5:
                    filmStudio.ShowMostProfitableMovie();
                    break;

                case 6:
                    mabmbambamba = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        break;


    case 3:
        Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Real Estate Company!");

        FinanceManagerOfARealEstateCompany realEstate = new();

        bool parizi = true;

        while (parizi)
        {
            Console.WriteLine();
            Console.WriteLine("Available Methods:");
            Console.WriteLine("1. Add Property");
            Console.WriteLine("2. Add Revenue");
            Console.WriteLine("3. Add Expense");
            Console.WriteLine("4. Show Property Profit");
            Console.WriteLine("5. Show Most Profitable Property");
            Console.WriteLine("6. Show Available Properties");
            Console.WriteLine("7. Generate Financial Report");
            Console.WriteLine("8. Exit");

            Console.WriteLine("Choose A Method:");

            int realEstateMethod = Convert.ToInt32(Console.ReadLine());

            switch (realEstateMethod)
            {
                case 1:
                    realEstate.AddProperty();
                    break;

                case 2:
                    realEstate.AddRevenue();
                    break;

                case 3:
                    Console.WriteLine("Enter Property ID:");
                    int expenseId = Convert.ToInt32(Console.ReadLine());

                    Property expenseProperty = realEstate.FindPropertyById(expenseId);

                    if (expenseProperty != null)
                    {
                        realEstate.AddExpense(expenseProperty);
                    }
                    else
                    {
                        Console.WriteLine("Property not found!");
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter Property ID:");
                    int profitId = Convert.ToInt32(Console.ReadLine());

                    Property profitProperty = realEstate.FindPropertyById(profitId);

                    if (profitProperty != null)
                    {
                        realEstate.CalculatePropertyProfit(profitProperty);
                    }
                    else
                    {
                        Console.WriteLine("Property not found!");
                    }
                    break;

                case 5:
                    realEstate.ShowMostProfitableProperty();
                    break;

                case 6:
                    realEstate.ShowAvailableProperties();
                    break;

                case 7:
                    realEstate.GenerateFinancialReport();
                    break;

                case 8:
                    parizi = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        break;


    case 4:
        Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Luxury Fashion Brand!");

        LuxuryBrandApplication application = new();
        FinanceManagerOfALuxuryClothingBrand selectedBrand = application.ApplyToBrand();

        if (selectedBrand == null)
            break;

        LuxuryBrandProduct luxury = new();

        bool luxuryRunning = true;

        while (luxuryRunning)
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome To {selectedBrand.Name}!");
            Console.WriteLine("Available Methods:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Sell Product");
            Console.WriteLine("4. Add Expense");
            Console.WriteLine("5. Calculate Revenue");
            Console.WriteLine("6. Calculate Profit");
            Console.WriteLine("7. Generate Financial Report");
            Console.WriteLine("8. Show Most Profitable Brand");
            Console.WriteLine("9. Exit");

            Console.WriteLine("Choose A Method:");

            int luxuryMethod = Convert.ToInt32(Console.ReadLine());

            switch (luxuryMethod)
            {
                case 1:
                    Console.WriteLine("Enter Product Name:");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Enter Product Price:");
                    decimal price = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Enter Product Stock:");
                    int stock = Convert.ToInt32(Console.ReadLine());

                    luxury.AddProduct(selectedBrand.Name, productName, price, stock);
                    break;

                case 2:
                    Console.WriteLine("Enter Product Name:");
                    string removeName = Console.ReadLine();

                    luxury.RemoveProduct(selectedBrand.Name, removeName);
                    break;

                case 3:
                    Console.WriteLine("Enter Product Name:");
                    string sellName = Console.ReadLine();

                    Console.WriteLine("Enter Quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    luxury.SellProduct(selectedBrand.Name, sellName, quantity);
                    break;

                case 4:
                    Console.WriteLine("Enter Expense Amount:");
                    decimal expense = Convert.ToDecimal(Console.ReadLine());

                    luxury.AddExpense(selectedBrand.Name, expense);
                    break;

                case 5:
                    Console.WriteLine($"Revenue: {luxury.CalculateRevenue(selectedBrand.Name):C}");
                    break;

                case 6:
                    Console.WriteLine($"Profit: {luxury.CalculateProfit(selectedBrand.Name):C}");
                    break;

                case 7:
                    luxury.GenerateFinancialReport();
                    break;

                case 8:
                    luxury.ShowMostProfitableBrand();
                    break;

                case 9:
                    luxuryRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        break;


    case 5:
        Console.WriteLine("Congratulations! You Are Now The Finance Manager Of A Formula Racing Team!");
        break;

    default:
        Console.WriteLine("Invalid Choice! Please Select A Number Between 0 And 5.");
        break;
}
