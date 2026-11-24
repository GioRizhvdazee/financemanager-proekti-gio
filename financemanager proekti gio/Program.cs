
// Football League 
// Airline 
// Film Studio  
// Real Estate
// Luxury Fashion Brand

using financemanager_proekti_gio;
using financemanager_proekti_gio.Airline_Company_Finance;
using financemanager_proekti_gio.FinanceManagerOfAFilmStudio;
using financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder;
using financemanager_proekti_gio.FinanceManagerOfARealEstateCompany;
using financemanager_proekti_gio.Football_Finance;
using Spectre.Console;
using static financemanager_proekti_gio.FinanceManagerOfAFilmStudio.FinanceManagerOfAFilmStudio;

AnsiConsole.MarkupLine("Congratulations! We Saw That You Had [#FFD700]Experience[/] In Running A Part Of Big Companies.");
AnsiConsole.MarkupLine("Your Role Was Being A [#FFD700]Finance Manager[/]. We Have A Couple Of [#FFD700]Offers[/] For You");
// mas chatgpt-m maswavla rogor gavaketo es spectre console-ti ferebi, dzaan 

Console.WriteLine();

AnsiConsole.MarkupLine("[#FFD700]Available Positions:[/]");
AnsiConsole.MarkupLine("1. Football League");
AnsiConsole.MarkupLine("2. Airline");
AnsiConsole.MarkupLine("3. Film Studio");
AnsiConsole.MarkupLine("4. Real Estate");
AnsiConsole.MarkupLine("5. Luxury Fashion Brand");

Console.WriteLine();

AnsiConsole.MarkupLine("[#FFD700]Please Choose Your Position:[/]");

int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        {
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

            while (true)
            {
                Console.WriteLine();

                AnsiConsole.MarkupLine("[#FFD700]Available Football Leagues:[/]");

                for (int ligebi = 0; ligebi < leagues.Count; ligebi++)
                {
                    AnsiConsole.MarkupLine($"{ligebi}. {Markup.Escape(leagues[ligebi].Name)}");
                }

                AnsiConsole.MarkupLine("[#FFD700]Choose A League (-1 To Exit):[/]");

                int leagueChoice = Convert.ToInt32(Console.ReadLine());

                if (leagueChoice == -1)
                {
                    break;
                }

                if (leagueChoice < 0 || leagueChoice >= leagues.Count)
                {
                    AnsiConsole.MarkupLine("[red]Invalid League Choice![/]");
                    continue;
                }

                Leagues selectedLeague = leagues[leagueChoice];

                bool accepted = selectedLeague.Apply();

                if (!accepted)
                {
                    AnsiConsole.MarkupLine("[yellow]You Can Apply To Another League![/]");
                    continue;
                }

                bool running = true;

                while (running)
                {
                    Console.WriteLine();

                    AnsiConsole.MarkupLine("[#FFD700]Available Methods:[/]");
                    AnsiConsole.MarkupLine("1. Check Team Budget");
                    AnsiConsole.MarkupLine("2. Calculate League Profit");
                    AnsiConsole.MarkupLine("3. Exit");

                    AnsiConsole.Markup("[#FFD700]Choose A Method:[/] ");

                    int method = Convert.ToInt32(Console.ReadLine());

                    switch (method)
                    {
                        case 1:
                            {
                                Console.Write("Enter Team Name: ");
                                string teamName = Console.ReadLine();

                                selectedLeague.ShowTeamBudget(teamName);
                                break;
                            }

                        case 2:
                            selectedLeague.CalculateLeaugeProfit();
                            break;

                        case 3:
                            running = false;
                            AnsiConsole.MarkupLine("[green]Goodbye![/]");
                            break;

                        default:
                            AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
                            break;
                    }
                }

                break;
            }

            break;
        }

    case 2:
        {
            AnsiConsole.MarkupLine(
                "Congratulations! You Are Now The [#FFD700]Finance Manager[/] Of An Airline Company!");

            AirlineCompanyFinance.FinanceManagerOfAnAirlineCompany finance = new();

            int revenueId = 1;
            int expenseId = 1;
            int refundId = 1;

            bool airlineRunning = true;

            while (airlineRunning)
            {
                Console.WriteLine();

                AnsiConsole.MarkupLine("[#FFD700]Available Methods:[/]");

                AnsiConsole.MarkupLine("1. Add Revenue");
                AnsiConsole.MarkupLine("2. Add Expense");
                AnsiConsole.MarkupLine("3. Add Refund");
                AnsiConsole.MarkupLine("4. Show Most Profitable Flight(Firstly, Add Revenue.)");
                AnsiConsole.MarkupLine("5. Exit");

                int airlineMethod = AnsiConsole.Ask<int>("[#FFD700]Choose A Method:[/]");

                switch (airlineMethod)
                {
                    case 1:
                        {
                            int flightId = AnsiConsole.Ask<int>("Enter Flight ID:");
                            decimal revenueAmount = AnsiConsole.Ask<decimal>("Enter Revenue Amount:");

                            finance.AddRevenue(
                                new AirlineCompanyFinance.RevenueOfAnAirlineCompany
                                {
                                    Id = revenueId++,
                                    FlightId = flightId,
                                    Amount = revenueAmount,
                                    Date = DateTime.Now
                                });

                            AnsiConsole.MarkupLine("[green]Revenue Added Successfully![/]");
                            break;
                        }

                    case 2:
                        {
                            string expenseType = AnsiConsole.Ask<string>("Enter Expense Type:");
                            string description = AnsiConsole.Ask<string>("Enter Description:");
                            decimal expenseAmount = AnsiConsole.Ask<decimal>("Enter Expense Amount:");

                            finance.AddExpense(
                                new AirlineCompanyFinance.ExpenseOfAnAirlineCompany
                                {
                                    Id = expenseId++,
                                    Type = expenseType,
                                    Description = description,
                                    Amount = expenseAmount,
                                    Date = DateTime.Now
                                });

                            AnsiConsole.MarkupLine("[green]Expense Added Successfully![/]");
                            break;
                        }

                    case 3:
                        {
                            int bookingId = AnsiConsole.Ask<int>("Enter Booking ID:");
                            decimal refundAmount = AnsiConsole.Ask<decimal>("Enter Refund Amount:");

                            finance.AddRefund(
                                new AirlineCompanyFinance.RefundOfAnAirlineCompany
                                {
                                    Id = refundId++,
                                    BookingId = bookingId,
                                    Amount = refundAmount,
                                    Date = DateTime.Now
                                });

                            AnsiConsole.MarkupLine("[green]Refund Added Successfully![/]");
                            break;
                        }
                    case 4:
                        finance.ShowMostProfitableFlight();
                        break;
                    case 5:
                        {
                            AirlineCompanyFinance.FinancialReportOfAnAirlineCompany report =
                                finance.GenerateReport();

                            var table = new Table().Border(TableBorder.Rounded);

                            table.Title = new TableTitle("[#FFD700]Airline Financial Report[/]");

                            table.AddColumn("Metric");
                            table.AddColumn("Amount");

                            table.AddRow("Total Revenue", report.TotalRevenue.ToString());
                            table.AddRow("Total Expenses", report.TotalExpenses.ToString());
                            table.AddRow("Total Refunds", report.TotalRefunds.ToString());
                            table.AddRow("Net Profit", report.NetProfit.ToString());

                            AnsiConsole.Write(table);

                            finance.SerializeReport();

                            AnsiConsole.MarkupLine(
                                "[green]Financial Report Saved Successfully![/]");

                            airlineRunning = false;
                            break;
                        }

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
                        break;
                }
            }
            //dzlivs done

            break;
        }

    case 3:
        {
            AnsiConsole.MarkupLine(
                "Congratulations! You Are Now The [#FFD700]Finance Manager[/] Of A Film Studio!");

            FinanceManagerOfAFilmStudio filmStudio = new();

            bool mabmbambamba = true;

            while (mabmbambamba)
            {
                Console.WriteLine();

                AnsiConsole.MarkupLine("[#FFD700]Available Methods:[/]");
                AnsiConsole.MarkupLine("1. Add Movie");
                AnsiConsole.MarkupLine("2. Add Revenue");
                AnsiConsole.MarkupLine("3. Add Expense");
                AnsiConsole.MarkupLine("4. Show Movie Profit");
                AnsiConsole.MarkupLine("5. Show Most Profitable Movie");
                AnsiConsole.MarkupLine("6. Generate Financial Report");
                AnsiConsole.MarkupLine("7. Exit");

                AnsiConsole.Markup("[#FFD700]Choose A Method:[/] ");

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
                        {
                            FinancialReportOfAFilmStudio filmreport =
                                filmStudio.GenerateReport();

                            var table = new Table().Border(TableBorder.Rounded);

                            table.Title = new TableTitle("[#FFD700]Film Studio Financial Report[/]");

                            table.AddColumn("Metric");
                            table.AddColumn("Amount");

                            table.AddRow("Total Movies", filmreport.TotalMovies.ToString());
                            table.AddRow("Total Revenue", filmreport.TotalRevenue.ToString());
                            table.AddRow("Total Expenses", filmreport.TotalExpenses.ToString());
                            table.AddRow("Net Profit", filmreport.NetProfit.ToString());

                            AnsiConsole.Write(table);

                            filmStudio.SerializeReport();

                            AnsiConsole.MarkupLine("[green]Report Saved Successfully![/]");
                            break;
                        }

                    case 7:
                        mabmbambamba = false;
                        AnsiConsole.MarkupLine("[green]Goodbye![/]");
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
                        break;
                }
            }

            break;
        }

    case 4:
        {
            AnsiConsole.MarkupLine(
                "Congratulations! You Are Now The [#FFD700]Finance Manager[/] Of A Real Estate Company!");

            FinanceManagerOfARealEstateCompany realEstate = new();

            bool realEstateRunning = true;

            while (realEstateRunning)
            {
                Console.WriteLine();

                AnsiConsole.MarkupLine("[#FFD700]Available Methods:[/]");
                AnsiConsole.MarkupLine("1. Add Property");
                AnsiConsole.MarkupLine("2. Add Revenue");
                AnsiConsole.MarkupLine("3. Add Expense");
                AnsiConsole.MarkupLine("4. Show Property Profit");
                AnsiConsole.MarkupLine("5. Show Most Profitable Property");
                AnsiConsole.MarkupLine("6. Show Available Properties");
                AnsiConsole.MarkupLine("7. Sell Property");
                AnsiConsole.MarkupLine("8. Rent Property");
                AnsiConsole.MarkupLine("9. Generate Financial Report");
                AnsiConsole.MarkupLine("10. Exit");

                int method = AnsiConsole.Ask<int>("[#FFD700]Choose A Method:[/]");

                switch (method)
                {
                    case 1:
                        realEstate.AddProperty();
                        break;

                    case 2:
                        realEstate.AddRevenue();
                        break;

                    case 3:
                        {
                            int expenseId = AnsiConsole.Ask<int>("Enter Property ID:");

                            Property? expenseProperty =
                                realEstate.FindPropertyById(expenseId);

                            if (expenseProperty != null)
                            {
                                realEstate.AddExpense(expenseProperty);
                            }
                            else
                            {
                                AnsiConsole.MarkupLine("[red]Property Not Found![/]");
                            }

                            break;
                        }

                    case 4:
                        {
                            int profitId = AnsiConsole.Ask<int>("Enter Property ID:");

                            Property? profitProperty =
                                realEstate.FindPropertyById(profitId);

                            if (profitProperty != null)
                            {
                                realEstate.CalculatePropertyProfit(profitProperty);
                            }
                            else
                            {
                                AnsiConsole.MarkupLine("[red]Property Not Found![/]");
                            }

                            break;
                        }

                    case 5:
                        realEstate.ShowMostProfitableProperty();
                        break;

                    case 6:
                        realEstate.ShowAvailableProperties();
                        break;

                    case 7:
                        {
                            int sellId = AnsiConsole.Ask<int>("Enter Property ID:");

                            Property? sellProperty =
                                realEstate.FindPropertyById(sellId);

                            if (sellProperty != null)
                            {
                                realEstate.SellProperty(sellProperty);
                            }
                            else
                            {
                                AnsiConsole.MarkupLine("[red]Property Not Found![/]");
                            }

                            break;
                        }

                    case 8:
                        {
                            int rentId = AnsiConsole.Ask<int>("Enter Property ID:");

                            Property? rentProperty =
                                realEstate.FindPropertyById(rentId);

                            if (rentProperty != null)
                            {
                                realEstate.RentProperty(rentProperty);
                            }
                            else
                            {
                                AnsiConsole.MarkupLine("[red]Property Not Found![/]");
                            }

                            break;
                        }

                    case 9:
                        {
                            var report = realEstate.GenerateReport();

                            AnsiConsole.MarkupLine($"Total Properties: {report.TotalProperties}");
                            AnsiConsole.MarkupLine($"Available Properties: {report.AvailableProperties}");
                            AnsiConsole.MarkupLine($"Total Purchase Value: {report.TotalPurchaseValue}");
                            AnsiConsole.MarkupLine($"Total Selling Value: {report.TotalSellingValue}");
                            AnsiConsole.MarkupLine($"Total Expenses: {report.TotalExpenses}");
                            AnsiConsole.MarkupLine($"Potential Property Profit: {report.PotentialPropertyProfitt}");
                            AnsiConsole.MarkupLine($"Recorded Revenue: {report.RecordedRevenue}");

                            realEstate.SerializeReport();

                            AnsiConsole.MarkupLine(
                                "[green]Financial Report Saved Successfully![/]");

                            break;
                        }

                    case 10:
                        realEstateRunning = false;
                        AnsiConsole.MarkupLine("[green]Goodbye![/]");
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
                        break;
                }
            }

            break;
        }

    case 5:
        {
            AnsiConsole.MarkupLine(
                "Congratulations! You Are Now The [#FFD700]Finance Manager[/] Of A Luxury Fashion Brand!");

            LuxuryBrandApplication application = new();

            FinanceManagerOfALuxuryClothingBrand selectedBrand =
                application.ApplyToBrand();

            if (selectedBrand == null)
            {
                break;
            }

            LuxuryBrandProduct luxury = new();

            bool luxuryRunning = true;

            while (luxuryRunning)
            {
                Console.WriteLine();

                AnsiConsole.MarkupLine(
                    $"Welcome To [#FFD700]{Markup.Escape(selectedBrand.Name)}[/]!");

                AnsiConsole.MarkupLine("[#FFD700]Available Methods:[/]");

                AnsiConsole.MarkupLine("1. Add Product");
                AnsiConsole.MarkupLine("2. Remove Product");
                AnsiConsole.MarkupLine("3. Sell Product");
                AnsiConsole.MarkupLine("4. Add Expense");
                AnsiConsole.MarkupLine("5. Calculate Revenue");
                AnsiConsole.MarkupLine("6. Calculate Profit");
                AnsiConsole.MarkupLine("7. Generate Financial Report");
                AnsiConsole.MarkupLine("8. Show Most Profitable Brand");
                AnsiConsole.MarkupLine("9. Exit");

                AnsiConsole.Markup("[#FFD700]Choose A Method:[/] ");

                int luxuryMethod = Convert.ToInt32(Console.ReadLine());

                switch (luxuryMethod)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Product Name:");
                            string productName = Console.ReadLine();

                            Console.WriteLine("Enter Product Price:");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.WriteLine("Enter Product Stock:");
                            int stock = Convert.ToInt32(Console.ReadLine());

                            luxury.AddProduct(selectedBrand.Name, productName, price, stock);
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Enter Product Name:");
                            string removeName = Console.ReadLine();

                            luxury.RemoveProduct(selectedBrand.Name, removeName);
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Enter Product Name:");
                            string sellName = Console.ReadLine();

                            Console.WriteLine("Enter Quantity:");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            luxury.SellProduct(selectedBrand.Name, sellName, quantity);
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Enter Expense Amount:");
                            decimal expense = Convert.ToDecimal(Console.ReadLine());

                            luxury.AddExpense(selectedBrand.Name, expense);
                            break;
                        }

                    case 5:
                        AnsiConsole.MarkupLine(
                            $"Revenue: [green]{luxury.CalculateRevenue(selectedBrand.Name)}[/]");
                        break;

                    case 6:
                        AnsiConsole.MarkupLine(
                            $"[#FFD700]Profit: {luxury.CalculateProfit(selectedBrand.Name)}[/]");
                        break;

                    case 7:
                        luxury.GenerateFinancialReport();
                        luxury.SerializeReport();
                        break;

                    case 8:
                        luxury.ShowMostProfitableBrand();
                        break;

                    case 9:
                        luxuryRunning = false;
                        AnsiConsole.MarkupLine("[green]Goodbye![/]");
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid Choice![/]");
                        break;
                }
            }

            break;
        }

    default:
        AnsiConsole.MarkupLine(
            "[red]Invalid Choice![/] Please Select A Number Between 1 And 5.");
        break;
}
