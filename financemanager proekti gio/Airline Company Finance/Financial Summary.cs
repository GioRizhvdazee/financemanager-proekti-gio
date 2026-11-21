namespace financemanager_proekti_gio.Airline_Company_Finance
{
    internal class Financial_SummaryOfAnAirlineCompany
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalRefunds { get; set; }
        public decimal NetProfit =>
            TotalRevenue - TotalExpenses - TotalRefunds;
    }
}
