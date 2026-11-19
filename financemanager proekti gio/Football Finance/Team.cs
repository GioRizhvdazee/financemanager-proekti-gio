namespace financemanager_proekti_gio.Football_Finance
{
    internal class Team
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Budget { get; set; }

        public Team(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}