namespace financemanager_proekti_gio.FinanceManagerOfALuxuryClothingBrandFolder
{
    internal class LuxuryBrandApplication
    {
        public List<FinanceManagerOfALuxuryClothingBrand> Brands = new()
        {
            new("Louis Vuitton", 35),
            new("Chanel", 30),
            new("Gucci", 45),
            new("Prada", 55),
            new("Burberry", 70),
            new("Dior", 35),
            new("Versace", 65),
            new("Balenciaga", 60),
            new("Ralph Lauren", 75),
            new("Hermes", 20)
        };

        public FinanceManagerOfALuxuryClothingBrand ApplyToBrand()
        {
            // gadavakete metki mirchevnia bool sityva = true, while(sityva){...} magram erori iyo da davabrune pirdapir true
            while (true)
            {
                Console.WriteLine("Available Luxury Brands:");

                for (int i = 0; i < Brands.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {Brands[i].Name} - {Brands[i].AcceptancePercentage}%");
                }

                Console.WriteLine("0. Exit");
                Console.Write("Choose Your Brand: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Please Enter A Valid Number!");
                    continue;
                }

                if (choice == 0)
                {
                    return null;
                }

                if (choice < 1 || choice > Brands.Count)
                // || quickfixma damiwera idk ra ari
                {
                    Console.WriteLine("Invalid Brand Choice!");
                    continue;
                }

                FinanceManagerOfALuxuryClothingBrand selectedBrand =
                    Brands[choice - 1];
                //-1 radgan chemi 1-ze iwyeba tvla xolo zogadad 0-ze amitom rom daemtxves davwere -1

                bool accepted = selectedBrand.Apply();
                // mas apply method davwere wertilis mere da martla arsebobdaaa :)))

                if (accepted)
                {
                    return selectedBrand;
                }
                Console.WriteLine("You Can Apply To Another Brand!");
                // tu dagarejektes masin es cw
            }
        }
    }
}
