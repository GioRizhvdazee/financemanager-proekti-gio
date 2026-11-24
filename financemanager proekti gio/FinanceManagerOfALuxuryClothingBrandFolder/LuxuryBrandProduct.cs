using System.Text.Json;

namespace financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder
{
    internal class LuxuryBrandProduct
    {
        public Dictionary<string, List<LuxuryProduct>> Brands = new()
        {
            ["Louis Vuitton"] = new()
            {
                new("Neverfull Bag", 1800, 10),
                new("Speedy Bag", 1500, 8),
                new("Keepall", 2200, 5)
            },

            ["Chanel"] = new()
            {
                new("Classic Flap Bag", 10000, 5),
                new("2.55 Bag", 9500, 4),
                new("Tweed Jacket", 6000, 7)
            },

            ["Gucci"] = new()
            {
                new("Jackie Bag", 2800, 8),
                new("Marmont Bag", 2500, 10),
                new("Ace Sneakers", 850, 15)
            },

            ["Prada"] = new()
            {
                new("Re-Edition Bag", 1400, 10),
                new("Galleria Bag", 3500, 6),
                new("America's Cup Sneakers", 950, 12)
            },

            ["Burberry"] = new()
            {
                new("Trench Coat", 2500, 8),
                new("Cashmere Scarf", 550, 15),
                new("Check Shirt", 650, 12)
            },

            ["Dior"] = new()
            {
                new("Saddle Bag", 4500, 5),
                new("Book Tote", 3500, 7),
                new("J'adore Perfume", 150, 20)
            },

            ["Versace"] = new()
            {
                new("Medusa Bag", 2200, 8),
                new("Barocco Shirt", 1200, 10),
                new("Greca Sneakers", 750, 12)
            },

            ["Balenciaga"] = new()
            {
                new("City Bag", 2500, 7),
                new("Triple S Sneakers", 1100, 10),
                new("Hourglass Bag", 2800, 6)
            },

            ["Ralph Lauren"] = new()
            {
                new("Polo Shirt", 120, 20),
                new("Oxford Shirt", 150, 15),
                new("Cable Knit Sweater", 250, 12)
            },

            ["Hermes"] = new()
            {
                new("Birkin Bag", 15000, 2),
                new("Kelly Bag", 12000, 3),
                new("Silk Scarf", 500, 10)
            }
        };

        public Dictionary<string, decimal> BrandExpenses = new();

        public class FinancialReportOfALuxuryBrand
        {
            public decimal TotalRevenue { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal TotalProfit { get; set; }
            public int TotalProducts { get; set; }
        }

        public LuxuryBrandProduct()
        {
            foreach (string brand in Brands.Keys)
            {
                BrandExpenses[brand] = 0;
            }

        }
        public FinancialReportOfALuxuryBrand GenerateReport()
        {
            return new FinancialReportOfALuxuryBrand
            {
                TotalRevenue = Brands.Keys.Sum(CalculateRevenue),
                TotalExpenses = BrandExpenses.Values.Sum(),
                TotalProfit = Brands.Keys.Sum(CalculateProfit),
                TotalProducts = Brands.Values.Sum(products => products.Sum(p => p.Stock))
                // me rac mewera is producktis saxeobas itvlida da ara stockshi ramdenia
            };
        }

        public void AddProduct(string brand, string name, decimal price, int stock)
        {
            if (!Brands.ContainsKey(brand))
            {
                Console.WriteLine("Brand Not Found!");
                return;
            }

            if (price <= 0 || stock < 0)
            {
                Console.WriteLine("Invalid Price Or Stock!");
                return;
            }

            Brands[brand].Add(new LuxuryProduct(name, price, stock));

            Console.WriteLine("Product Added Successfully!");
        }

        public void RemoveProduct(string brand, string productName)
        {
            if (!Brands.ContainsKey(brand))
            {
                Console.WriteLine("Brand Not Found!");
                return;
            }

            LuxuryProduct product = Brands[brand].FirstOrDefault(
                p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            // mas if(profuct-s erori konda da quick fixma gamiswora
            // au kidev ver vxvdebi es ragaa

            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
                return;
            }

            Brands[brand].Remove(product);

            Console.WriteLine("Product Removed Successfully!");
        }

        public void SellProduct(string brand, string productName, int quantity)
        {
            if (!Brands.ContainsKey(brand))
            {
                Console.WriteLine("Brand Not Found!");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Invalid Quantity!");
                return;
            }

            LuxuryProduct product = Brands[brand].FirstOrDefault(
                p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            // igive ak

            if (product == null)
            {
                Console.WriteLine("Product Not Found!");
                return;
            }

            if (product.Stock < quantity)
            {
                Console.WriteLine("Not Enough Stock!");
                return;
            }

            product.Stock -= quantity;
            product.TotalRevenue += product.Price * quantity;

            Console.WriteLine($"Sold {quantity} : {product.Name}");
            Console.WriteLine($"Total: {product.Price * quantity}");
        }

        public void AddExpense(string brand, decimal amount)
        {
            if (!BrandExpenses.ContainsKey(brand) || amount <= 0)
            // es ori joxi imdenjer kna quickfixma rom movidzie da "or"-s nisnavs
            {
                Console.WriteLine("Invalid Brand Or Expense!");
                return;
            }

            BrandExpenses[brand] += amount;

            Console.WriteLine("Expense Added Successfully!");
        }

        public decimal CalculateRevenue(string brand)
        {
            if (!Brands.ContainsKey(brand))
                return 0;

            return Brands[brand].Sum(p => p.TotalRevenue);
        }

        public decimal CalculateProfit(string brand)
        {
            if (!Brands.ContainsKey(brand))
                return 0;

            return CalculateRevenue(brand) - BrandExpenses[brand];
        }

        public void GenerateFinancialReport()
        {
            Console.WriteLine("Lixury Brand Financial Report");

            foreach (string brand in Brands.Keys)
            {
                Console.WriteLine($"Brand: {brand}");
                Console.WriteLine($"Products: {Brands[brand].Count}");
                Console.WriteLine($"Revenue: {CalculateRevenue(brand):C}");
                Console.WriteLine($"Expenses: {BrandExpenses[brand]:C}");
                Console.WriteLine($"Profit: {CalculateProfit(brand):C}");
                Console.WriteLine($"Total Stock: {Brands[brand].Sum(p => p.Stock)}");
            }
            FinancialReportOfALuxuryBrand report = GenerateReport();

            Console.WriteLine();
            Console.WriteLine("Overall Financial Report");
            Console.WriteLine($"Total Revenue: {report.TotalRevenue}");
            Console.WriteLine($"Total Expenses: {report.TotalExpenses}");
            Console.WriteLine($"Total Profit: {report.TotalProfit}");
            Console.WriteLine($"Total Products In Stock: {report.TotalProducts}");

        }
        public void SerializeReport()
        {
            FinancialReportOfALuxuryBrand report = GenerateReport();

            string json = JsonSerializer.Serialize(report, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("C:\\Users\\user\\OneDrive\\Desktop\\dg\\FinancialReport.json", json);
        }
        public FinancialReportOfALuxuryBrand DeserializeReport()
        {
            string json = File.ReadAllText("FinancialReport.json");

            return JsonSerializer.Deserialize<FinancialReportOfALuxuryBrand>(json)!;
        }

        public void ShowMostProfitableBrand()
        {
            if (!Brands.Any())
            {
                Console.WriteLine("No Brands Found!");
                return;
            }
            string brand = Brands.Keys
                .OrderByDescending(CalculateProfit)
                //klebadoba xshirad ar madgeba mara gamomadga
                .First();

            Console.WriteLine($"Most Profitable Brand: {brand}");
            Console.WriteLine($"Profit: {CalculateProfit(brand)}");
        }

    }
}
