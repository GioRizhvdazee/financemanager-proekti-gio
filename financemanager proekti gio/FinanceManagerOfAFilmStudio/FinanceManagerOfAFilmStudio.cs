using System.Text.Json;

namespace financemanager_proekti_gio.FinanceManagerOfAFilmStudio
{
    internal class FinanceManagerOfAFilmStudio
    {
        List<Movie> Movies = new()
        {
            new() { Id = 1, Title = "Interstellar", Director = "Christopher Nolan", ReleaseYear = 2014, Budget = 165000000, Revenue = 773800000, Rating = 10 },
            new() { Id = 2, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010, Budget = 160000000, Revenue = 839000000, Rating = 9.2 },
            new() { Id = 3, Title = "Avatar", Director = "James Cameron", ReleaseYear = 2009, Budget = 237000000, Revenue = 2923700000, Rating = 8 },
            new() { Id = 4, Title = "Titanic", Director = "James Cameron", ReleaseYear = 1997, Budget = 200000000, Revenue = 2264700000, Rating = 9.7 },
            new() { Id = 5, Title = "Joker", Director = "Todd Phillips", ReleaseYear = 2019, Budget = 55000000, Revenue = 1074000000, Rating = 9 },
            new() { Id = 6, Title = "Gladiator", Director = "Ridley Scott", ReleaseYear = 2000, Budget = 103000000, Revenue = 465000000, Rating = 8 },
            new() { Id = 7, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008, Budget = 185000000, Revenue = 1006000000, Rating = 8 },
            new() { Id = 8, Title = "The Matrix", Director = "Wachowskis", ReleaseYear = 1999, Budget = 63000000, Revenue = 467000000, Rating = 8.7 },
            new() { Id = 9, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972, Budget = 6000000, Revenue = 250000000, Rating = 6.8 },
            new() { Id = 10, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994, Budget = 8000000, Revenue = 213900000, Rating = 7.7 }
        };

        public void AddMovie()
        {
            if (Movies.Count >= 15)
            {
                Console.WriteLine("You have reached the maximum number of movies (15). Cannot add more.");
                // 15 maximumi, radgan mas tkven tkvit rom 10-20 sakmarisia tkvens proektsi yvelaferio, torem bevrad meti filmis chasma mindoda
                return;
            }
            else
            {
                Console.WriteLine("Enter Movie Title:");
                string title = Console.ReadLine();

                Console.WriteLine("Enter Director Name:");
                string director = Console.ReadLine();

                Console.WriteLine("Enter Release Year:");
                int releaseYear = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Budget:");
                decimal budget = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter Revenue:");
                decimal revenue = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter Rating (0-10):");
                double rating = Convert.ToDouble(Console.ReadLine());

                int newId = Movies.Max(m => m.Id) + 1;

                Movie newMovie = new()
                {
                    Id = newId,
                    Title = title,
                    Director = director,
                    ReleaseYear = releaseYear,
                    Budget = budget,
                    Revenue = revenue,
                    Rating = rating
                };

                Movies.Add(newMovie);
                //au mas movie newmovie da .add-is povna/mofikreba rtuli iyo
                Console.WriteLine($"Movie '{title}' added successfully with ID: {newId}.");
            }
        }

        public void AddRevenue()
        {
            if (Movies.Count == 0)
            {
                Console.WriteLine("No movies available to add revenue.");
                return;
            }
            else
            {
                Console.WriteLine("Enter Movie ID to add revenue:");
                //int movie_id_response = Convert.ToInt32(Console.ReadLine());
                string Movie_Id_Response = Console.ReadLine();
                //bool succsess = int.TryParse(Movie_Id_Response, out int movie_id_response); es dzaan areulia
                if (!int.TryParse(Movie_Id_Response, out int movie_id_response))
                {
                    Console.WriteLine("Invalid Movie ID!");
                    return;
                }
                //es jobia, prosta es ufro rtuli iyo

                Movie selectedMovie = Movies.Find(m => m.Id == movie_id_response);

                if (selectedMovie != null)
                {
                    Console.WriteLine($"Current Revenue for '{selectedMovie.Title}': {selectedMovie.Revenue}");

                    Console.WriteLine("Enter additional revenue amount:");
                    decimal additionalRevenue = Convert.ToDecimal(Console.ReadLine());

                    selectedMovie.Revenue += additionalRevenue;

                    Console.WriteLine($"Updated Revenue for '{selectedMovie.Title}': {selectedMovie.Revenue}");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
        }

        public void AddExpense()
        {
            if (Movies.Count == 0)
            {
                Console.WriteLine("No movies available to add expense.");
                return;
            }
            else
            {
                Console.WriteLine("Enter Movie ID to add expense:");
                string Movie_Id_Response = Console.ReadLine();

                if (!int.TryParse(Movie_Id_Response, out int movie_id_response))
                {
                    Console.WriteLine("Invalid Movie ID!");
                    return;
                }
                // esec jobia imas, ufro gasagebi, praktikuli da konkretulia

                Movie selectedMovie = Movies.Find(m => m.Id == movie_id_response);
                if (selectedMovie != null)
                {
                    Console.WriteLine($"Current Budget for '{selectedMovie.Title}': {selectedMovie.Budget}");

                    Console.WriteLine("Enter additional expense amount:");
                    decimal additionalExpense = Convert.ToDecimal(Console.ReadLine());

                    selectedMovie.Budget += additionalExpense;

                    Console.WriteLine($"Updated Budget for '{selectedMovie.Title}': {selectedMovie.Budget}");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
        }

        public void ShowMovieProfit()
        {
            if (Movies.Count == 0)
            {
                Console.WriteLine("No movies available to show profit.");
                return;
            }
            else
            {
                Console.WriteLine("Enter Movie ID to show profit:");
                int movie_id_response = Convert.ToInt32(Console.ReadLine());
                // es converti galeriasi vnaxe telefonis

                Movie selectedMovie = Movies.Find(m => m.Id == movie_id_response);
                // mas es potential fix-ma damiwera amis zemota xazi yvela metodsi, me frcxilebsi movie_id_response mewera

                if (selectedMovie != null)
                {
                    decimal profit = selectedMovie.Revenue - selectedMovie.Budget;
                    Console.WriteLine($"Profit for '{selectedMovie.Title}': {profit}");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
        }

        public void ShowMostProfitableMovie()
        {
            if (Movies.Count == 0)
            {
                Console.WriteLine("No movies available to show most profitable movie.");
                return;
            }
            else
            {
                Movie mostProfitableMovie = Movies.OrderByDescending(m => m.Revenue - m.Budget).FirstOrDefault();
                // es xazi uerorod ro davwere ar mjeraa

                if (mostProfitableMovie != null)
                {
                    Console.WriteLine($"Most Profitable Movie: {mostProfitableMovie.Title}, Profit: {mostProfitableMovie.Revenue - mostProfitableMovie.Budget}");
                }
                else
                {
                    Console.WriteLine("No profitable movies found.");
                }
            }
        }
        public class FinancialReportOfAFilmStudio
        {
            public int TotalMovies { get; set; }
            public decimal TotalRevenue { get; set; }
            public decimal TotalExpenses { get; set; }

            public decimal NetProfit =>
                TotalRevenue - TotalExpenses;
        }

        public FinancialReportOfAFilmStudio GenerateReport()
        {
            return new FinancialReportOfAFilmStudio
            {
                TotalMovies = Movies.Count,
                TotalRevenue = Movies.Sum(m => m.Revenue),
                TotalExpenses = Movies.Sum(m => m.Budget)
            };
        }
        public void SerializeReport()
        {
            FinancialReportOfAFilmStudio report = GenerateReport();

            string json = JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("FinancialReport.json", json);
        }
        public FinancialReportOfAFilmStudio DeserializeReport()
        {
            string json = File.ReadAllText("C:\\Users\\user\\OneDrive\\Desktop\\dg\\FinancialReport.json");

            return JsonSerializer.Deserialize<FinancialReportOfAFilmStudio>(json)!;
        }

        // mas chatgpt-m mitxra ideebi metodebis(yvelasi ara) :)
    }
}
