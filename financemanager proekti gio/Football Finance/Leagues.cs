
namespace financemanager_proekti_gio
{
    internal class Leagues
    {
        public string Name { get; set; }
        public int HiringChance { get; set; }

        public Leagues(string name, int hiringChance)
        {
            Name = name;
            HiringChance = hiringChance;
        }

        public bool Apply()
        {

            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            if (randomNumber < HiringChance)
            {
                Console.WriteLine($"Congratulations! You Applied For {Name}!");
                return true;
            }
            else
            {
                Console.WriteLine($"Unfortunately, Your Application For The {Name} Was Rejected!");
                return false;

            }
        }
        public virtual void ShowTeamBudget(string teamName)
        {
            Console.WriteLine("Team search is not available.");
        }
    }
}
