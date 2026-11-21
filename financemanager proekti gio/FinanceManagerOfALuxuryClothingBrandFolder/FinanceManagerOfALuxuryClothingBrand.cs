namespace financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder
{
    internal class FinanceManagerOfALuxuryClothingBrand
    {
    public string Name { get; set; }
        public int AcceptancePercentage { get; set; }

        public FinanceManagerOfALuxuryClothingBrand(string name, int acceptancePercentage)
        {
            Name = name;
            AcceptancePercentage = acceptancePercentage;
        }

        public bool Apply()
        {
            Console.WriteLine($"Applying to {Name}...");
            Console.WriteLine($"Acceptance Chance: {AcceptancePercentage}%");

            Random random = new Random();

            int result = random.Next(1, 101);

            if (result <= AcceptancePercentage)
            {
                Console.WriteLine($"Congratulations! {Name} Accepted Your Application!");
                return true;
            }
            else
            {
                Console.WriteLine($"Unfortunately, {Name} Rejected Your Application.");
                return false;
            }
        }
    }
}

