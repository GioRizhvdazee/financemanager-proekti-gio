using financemanager_proekti_gio.FinanceManagerOfARealEstateCompany;
internal class FinanceManagerOfARealEstateCompany
{
    List<Property> Properties = new()
        {
            new() { Id = 1, Address = "Rustaveli Avenue 15", City = "Tbilisi", PropertyType = "Apartment", PurchasePrice = 120000, SellingPrice = 165000, MonthlyRent = 1200, Expenses = 5000, IsAvailable = true, Area = 85, Bedrooms = 3 },
            new() { Id = 2, Address = "Chavchavadze Avenue 42", City = "Tbilisi", PropertyType = "Luxury Apartment", PurchasePrice = 250000, SellingPrice = 340000, MonthlyRent = 2500, Expenses = 12000, IsAvailable = false, Area = 140, Bedrooms = 4 },
            new() { Id = 3, Address = "Batumi Boulevard 8", City = "Batumi", PropertyType = "Apartment", PurchasePrice = 95000, SellingPrice = 135000, MonthlyRent = 900, Expenses = 4000, IsAvailable = true, Area = 70, Bedrooms = 2 },
            new() { Id = 4, Address = "Old Batumi 21", City = "Batumi", PropertyType = "Private House", PurchasePrice = 180000, SellingPrice = 260000, MonthlyRent = 1800, Expenses = 15000, IsAvailable = false, Area = 220, Bedrooms = 5 },
            new() { Id = 5, Address = "Vake 12", City = "Tbilisi", PropertyType = "Penthouse", PurchasePrice = 400000, SellingPrice = 550000, MonthlyRent = 4000, Expenses = 20000, IsAvailable = true, Area = 200, Bedrooms = 4 },
            new() { Id = 6, Address = "Gonio 33", City = "Batumi", PropertyType = "Villa", PurchasePrice = 500000, SellingPrice = 720000, MonthlyRent = 5000, Expenses = 30000, IsAvailable = false, Area = 350, Bedrooms = 6 },
            new() { Id = 7, Address = "Saburtalo 19", City = "Tbilisi", PropertyType = "Office", PurchasePrice = 220000, SellingPrice = 310000, MonthlyRent = 2200, Expenses = 10000, IsAvailable = true, Area = 180, Bedrooms = 0 },
            new() { Id = 8, Address = "Kutaisi Center 5", City = "Kutaisi", PropertyType = "Commercial Building", PurchasePrice = 300000, SellingPrice = 420000, MonthlyRent = 3500, Expenses = 18000, IsAvailable = false, Area = 450, Bedrooms = 0 },
            new() { Id = 9, Address = "Gudauri Residence 14", City = "Gudauri", PropertyType = "Ski Apartment", PurchasePrice = 150000, SellingPrice = 210000, MonthlyRent = 1500, Expenses = 8000, IsAvailable = true, Area = 95, Bedrooms = 3 },
            new() { Id = 10, Address = "Mtskheta Road 7", City = "Mtskheta", PropertyType = "Land", PurchasePrice = 80000, SellingPrice = 125000, MonthlyRent = 0, Expenses = 3000, IsAvailable = true, Area = 1200, Bedrooms = 0 }
        };

    decimal TotalRevenue = 0;

    public void AddProperty()
    {
        if (Properties.Count >= 15)
        {
            Console.WriteLine("Maximum number of properties reached.");
            return;
        }

        Console.WriteLine("Enter Your Property Details:");

        Console.Write("ID: ");
        int newid = Convert.ToInt32(Console.ReadLine());

        Console.Write("Address: ");
        string newaddress = Console.ReadLine();

        Console.Write("City: ");
        string newcity = Console.ReadLine();

        Console.Write("Property Type: ");
        string newpropertytype = Console.ReadLine();

        Console.Write("Purchase Price: ");
        decimal newpurchaseprice = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Selling Price: ");
        decimal newsellingprice = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Monthly Rent: ");
        decimal newmonthlyrent = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Expenses: ");
        decimal newexpenses = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Area: ");
        double newarea = Convert.ToDouble(Console.ReadLine());

        Console.Write("Bedrooms: ");
        int newbedrooms = Convert.ToInt32(Console.ReadLine());

        Property newProperty = new Property()
        {
            Id = newid,
            Address = newaddress,
            City = newcity,
            PropertyType = newpropertytype,
            PurchasePrice = newpurchaseprice,
            SellingPrice = newsellingprice,
            MonthlyRent = newmonthlyrent,
            Expenses = newexpenses,
            Area = newarea,
            Bedrooms = newbedrooms,
            IsAvailable = true
        };

        Properties.Add(newProperty);

        Console.WriteLine($"Property at {newProperty.Address} added successfully.");
    }

    public void SellProperty(Property property)
    {
        if (property == null)
        {
            Console.WriteLine("Property cannot be null.");
            return;
        }

        if (property.IsAvailable)
        {
            property.IsAvailable = false;
            TotalRevenue += property.SellingPrice;

            Console.WriteLine($"Property at {property.Address} sold successfully!");
        }
        else
        {
            Console.WriteLine("This Property Is Not Available To Buy!");
        }
    }

    public Property FindPropertyById(int id)
    {
        return Properties.Find(p => p.Id == id);
    }

    public void RentProperty(Property property)
    {
        if (property == null)
        {
            Console.WriteLine("Property cannot be null.");
            return;
        }

        if (property.IsAvailable && property.MonthlyRent > 0)
        {
            property.IsAvailable = false;

            Console.WriteLine($"Property at {property.Address} rented successfully!");
        }
        else
        {
            Console.WriteLine("This Property Is Not Available To Rent!");
        }
    }

    public void AddExpense(Property property)
    {
        if (property == null)
        {
            Console.WriteLine("Property cannot be null.");
            return;
        }

        Console.WriteLine("Enter Expense Amount:");
        decimal expenseAmount = Convert.ToDecimal(Console.ReadLine());

        if (expenseAmount <= 0)
        {
            Console.WriteLine("Expense must be greater than zero.");
            return;
        }

        property.Expenses += expenseAmount;

        Console.WriteLine($"Expense: {expenseAmount} added successfully.");
    }

    public void AddRevenue()
    {
        Console.WriteLine("Enter Revenue Amount:");
        decimal revenueAmount = Convert.ToDecimal(Console.ReadLine());

        if (revenueAmount <= 0)
        {
            Console.WriteLine("Revenue must be greater than zero.");
            return;
        }

        TotalRevenue += revenueAmount;

        Console.WriteLine($"Revenue: {revenueAmount} added successfully.");
    }

    public void CalculatePropertyProfit(Property property)
    {
        if (property == null)
        {
            Console.WriteLine("Property cannot be null.");
            return;
        }

        decimal profit = property.SellingPrice - property.PurchasePrice - property.Expenses;

        Console.WriteLine($"The Profit for Property at {property.Address} is: {profit}");
    }

    public void ShowMostProfitableProperty()
    {
        Property mostProfitableProperty = null;
        decimal highestProfit = decimal.MinValue;

        foreach (var property in Properties)
        {
            decimal profit = property.SellingPrice - property.PurchasePrice - property.Expenses;

            if (profit > highestProfit)
            {
                highestProfit = profit;
                mostProfitableProperty = property;
            }
        }

        if (mostProfitableProperty != null)
        {
            Console.WriteLine($"The Most Profitable Property is at {mostProfitableProperty.Address} with a profit of {highestProfit}");
        }
        else
        {
            Console.WriteLine("There are no properties available.");
        }
    }

    public void ShowAvailableProperties()
    {
        Console.WriteLine("Available Properties:");

        foreach (var property in Properties)
        {
            if (property.IsAvailable)
            {
                Console.WriteLine($"ID: {property.Id}, Address: {property.Address}, City: {property.City}, Type: {property.PropertyType}, Price: {property.SellingPrice}, Rent: {property.MonthlyRent}");
            }
        }
    }

    public void GenerateFinancialReport()
    {
        decimal totalPurchaseValue = 0;
        decimal totalSellingValue = 0;
        decimal totalExpenses = 0;
        decimal totalProfit = 0;

        foreach (var property in Properties)
        {
            totalPurchaseValue += property.PurchasePrice;
            totalSellingValue += property.SellingPrice;
            totalExpenses += property.Expenses;

            totalProfit += property.SellingPrice
                         - property.PurchasePrice
                         - property.Expenses;
        }

        Console.WriteLine("Financial Report:");
        Console.WriteLine();
        Console.WriteLine($"Total Properties: {Properties.Count}");
        Console.WriteLine($"Available Properties: {Properties.FindAll(p => p.IsAvailable).Count}");
        Console.WriteLine($"Total Purchase Value: {totalPurchaseValue}");
        Console.WriteLine($"Total Selling Value: {totalSellingValue}");
        Console.WriteLine($"Total Expenses: {totalExpenses}");
        Console.WriteLine($"Potential Property Profit: {totalProfit}");
        Console.WriteLine($"Recorded Revenue: {TotalRevenue}");
    }
}