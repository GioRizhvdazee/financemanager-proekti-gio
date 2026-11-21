
namespace financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder
{
    internal class LuxuryProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal TotalRevenue { get; set; }

        public LuxuryProduct(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            TotalRevenue = 0;
        }
    }
}
