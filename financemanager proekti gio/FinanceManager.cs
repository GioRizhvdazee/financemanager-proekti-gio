namespace financemanager_proekti_gio
{
    internal class FinanceManager
    {

        public class Revenue
        {
            public int Id { get; set; }
            public int FlightId { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class Expense
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class Refund
        {
            public int Id { get; set; }
            public int BookingId { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class FinancialReport
        {
            public decimal TotalRevenue { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal TotalRefunds { get; set; }

            public decimal NetProfit =>
                TotalRevenue - TotalExpenses - TotalRefunds;
        }

        public class FinanceManagerOfAnAirlineCompany
        {


            private List<Revenue> revenues = new();
            private List<Expense> expenses = new();
            private List<Refund> refunds = new();

            public void AddRevenue(Revenue revenue)
            {
                revenues.Add(revenue);
            }

            public void AddExpense(Expense expense)
            {
                expenses.Add(expense);
            }

            public void AddRefund(Refund refund)
            {
                refunds.Add(refund);
            }

            public FinancialReport GenerateReport()
            {
                return new FinancialReport
                {
                    TotalRevenue = revenues.Sum(r => r.Amount),
                    TotalExpenses = expenses.Sum(e => e.Amount),
                    TotalRefunds = refunds.Sum(r => r.Amount)
                };
            }
        }
    }
}
