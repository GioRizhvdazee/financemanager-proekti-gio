namespace financemanager_proekti_gio
{
    internal class FinanceManager
    {

        public class RevenueOfAnAirlineCompany
        {
            public int Id { get; set; }
            public int FlightId { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class ExpenseOfAnAirlineCompany
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class RefundOfAnAirlineCompany
        {
            public int Id { get; set; }
            public int BookingId { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class FinancialReportOfAnAirlineCompany
        {
            public decimal TotalRevenue { get; set; }
            public decimal TotalExpenses { get; set; }
            public decimal TotalRefunds { get; set; }
            public decimal NetProfit =>
                TotalRevenue - TotalExpenses - TotalRefunds;
        }

        public class FinanceManagerOfAnAirlineCompany
        {


            private List<RevenueOfAnAirlineCompany> revenues = new();
            private List<ExpenseOfAnAirlineCompany> expenses = new();
            private List<RefundOfAnAirlineCompany> refunds = new();

            public void AddRevenue(RevenueOfAnAirlineCompany revenue)
            {
                revenues.Add(revenue);
            }

            public void AddExpense(ExpenseOfAnAirlineCompany expense)
            {
                expenses.Add(expense);
            }

            public void AddRefund(RefundOfAnAirlineCompany refund)
            {
                refunds.Add(refund);
            }

            public FinancialReportOfAnAirlineCompany GenerateReport()
            {
                return new FinancialReportOfAnAirlineCompany
                {
                    TotalRevenue = revenues.Sum(r => r.Amount),
                    TotalExpenses = expenses.Sum(e => e.Amount),
                    TotalRefunds = refunds.Sum(r => r.Amount)
                };
            }
        }
    }
}
