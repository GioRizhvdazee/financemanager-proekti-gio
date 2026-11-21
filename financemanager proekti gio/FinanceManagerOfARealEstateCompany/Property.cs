namespace financemanager_proekti_gio.FinanceManagerOfARealEstateCompany
{
    internal class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PropertyType { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal Expenses { get; set; }
        public bool IsAvailable { get; set; }
        public double Area { get; set; }
        public int Bedrooms { get; set; }
    }
}
