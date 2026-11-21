namespace financemanager_proekti_gio.FinanceManagerOfAFilmStudio
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public double Rating { get; set; }
        public decimal Profit => Revenue - Budget;

        public override string ToString()
        {
            return $"Movie ID: {Id}, Title: {Title}, Director: {Director}, Release Year: {ReleaseYear}, Budget: {Budget}, Revenue: {Revenue}, Profit: {Profit}, Rating: {Rating}";
        }
    }
}
