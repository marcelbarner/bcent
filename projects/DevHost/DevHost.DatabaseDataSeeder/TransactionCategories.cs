using Infrastructure;

namespace DevHost.DatabaseDataSeeder;

public static class TransactionCategories
{
    public static readonly TransactionCategory EarnedIncome = new()
    {
        Id = 1,
        Name = "Earned Income",
        Type = TransactionCategoryType.Income
    };

    public static readonly TransactionCategory Salary = new()
    {
        Id = 2,
        Name = "Salary",
        Type = TransactionCategoryType.Income,
        ParentCategory = EarnedIncome,
        ParentTransactionCategoryId = EarnedIncome.Id
    };

    public static readonly TransactionCategory SideJob = new()
    {
        Id = 3,
        Name = "Side Job",
        Type = TransactionCategoryType.Income,
        ParentCategory = EarnedIncome,
        ParentTransactionCategoryId = EarnedIncome.Id
    };

    public static readonly TransactionCategory SelfEmployment = new()
    {
        Id = 4,
        Name = "Self-Employment",
        Type = TransactionCategoryType.Income
    };

    public static readonly TransactionCategory SmallBusiness = new()
    {
        Id = 5,
        Name = "Small Business",
        Type = TransactionCategoryType.Income,
        ParentCategory = SelfEmployment,
        ParentTransactionCategoryId = SelfEmployment.Id
    };

    public static readonly TransactionCategory InvestmentIncome = new()
    {
        Id = 6,
        Name = "Investment Income",
        Type = TransactionCategoryType.Income
    };

    public static readonly TransactionCategory Interest = new()
    {
        Id = 7,
        Name = "Interest",
        Type = TransactionCategoryType.Income,
        ParentCategory = InvestmentIncome,
        ParentTransactionCategoryId = InvestmentIncome.Id
    };

    public static readonly TransactionCategory Dividends = new()
    {
        Id = 8,
        Name = "Dividends",
        Type = TransactionCategoryType.Income,
        ParentCategory = InvestmentIncome,
        ParentTransactionCategoryId = InvestmentIncome.Id
    };

    public static readonly TransactionCategory StockSales = new()
    {
        Id = 9,
        Name = "Stock Sales",
        Type = TransactionCategoryType.Income,
        ParentCategory = InvestmentIncome,
        ParentTransactionCategoryId = InvestmentIncome.Id
    };

    public static readonly TransactionCategory OtherIncome = new()
    {
        Id = 10,
        Name = "Other Income",
        Type = TransactionCategoryType.Income
    };

    public static readonly TransactionCategory GiftsIncome = new()
    {
        Id = 11,
        Name = "Gifts",
        Type = TransactionCategoryType.Income,
        ParentCategory = OtherIncome,
        ParentTransactionCategoryId = OtherIncome.Id
    };

    public static readonly TransactionCategory Housing = new()
    {
        Id = 12,
        Name = "Housing",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Rent = new()
    {
        Id = 13,
        Name = "Rent",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Housing,
        ParentTransactionCategoryId = Housing.Id
    };

    public static readonly TransactionCategory Utilities = new()
    {
        Id = 14,
        Name = "Utilities",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Housing,
        ParentTransactionCategoryId = Housing.Id
    };

    public static readonly TransactionCategory Electricity = new()
    {
        Id = 15,
        Name = "Electricity",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Housing,
        ParentTransactionCategoryId = Housing.Id
    };

    public static readonly TransactionCategory InternetPhone = new()
    {
        Id = 16,
        Name = "Internet/Phone",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Housing,
        ParentTransactionCategoryId = Housing.Id
    };

    public static readonly TransactionCategory LivingExpenses = new()
    {
        Id = 17,
        Name = "Living Expenses",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Groceries = new()
    {
        Id = 18,
        Name = "Groceries",
        Type = TransactionCategoryType.Expense,
        ParentCategory = LivingExpenses,
        ParentTransactionCategoryId = LivingExpenses.Id
    };

    public static readonly TransactionCategory Hygiene = new()
    {
        Id = 19,
        Name = "Hygiene",
        Type = TransactionCategoryType.Expense,
        ParentCategory = LivingExpenses,
        ParentTransactionCategoryId = LivingExpenses.Id
    };

    public static readonly TransactionCategory Household = new()
    {
        Id = 20,
        Name = "Household",
        Type = TransactionCategoryType.Expense,
        ParentCategory = LivingExpenses,
        ParentTransactionCategoryId = LivingExpenses.Id
    };

    public static readonly TransactionCategory Mobility = new()
    {
        Id = 21,
        Name = "Mobility",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory PublicTransport = new()
    {
        Id = 22,
        Name = "Public Transportation",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Mobility,
        ParentTransactionCategoryId = Mobility.Id
    };

    public static readonly TransactionCategory Car = new()
    {
        Id = 23,
        Name = "Car (Fuel, Insurance, Maintenance)",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Mobility,
        ParentTransactionCategoryId = Mobility.Id
    };

    public static readonly TransactionCategory Insurances = new()
    {
        Id = 24,
        Name = "Insurances",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory HealthInsurance = new()
    {
        Id = 25,
        Name = "Health Insurance",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Insurances,
        ParentTransactionCategoryId = Insurances.Id
    };

    public static readonly TransactionCategory LiabilityInsurance = new()
    {
        Id = 26,
        Name = "Liability Insurance",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Insurances,
        ParentTransactionCategoryId = Insurances.Id
    };

    public static readonly TransactionCategory HouseholdInsurance = new()
    {
        Id = 27,
        Name = "Household Insurance",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Insurances,
        ParentTransactionCategoryId = Insurances.Id
    };

    public static readonly TransactionCategory DisabilityInsurance = new()
    {
        Id = 28,
        Name = "Disability Insurance",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Insurances,
        ParentTransactionCategoryId = Insurances.Id
    };

    public static readonly TransactionCategory Leisure = new()
    {
        Id = 29,
        Name = "Leisure & Entertainment",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Streaming = new()
    {
        Id = 30,
        Name = "Streaming Services",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Leisure,
        ParentTransactionCategoryId = Leisure.Id
    };

    public static readonly TransactionCategory Hobbies = new()
    {
        Id = 31,
        Name = "Hobbies",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Leisure,
        ParentTransactionCategoryId = Leisure.Id
    };

    public static readonly TransactionCategory Travel = new()
    {
        Id = 32,
        Name = "Vacation & Travel",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Leisure,
        ParentTransactionCategoryId = Leisure.Id
    };

    public static readonly TransactionCategory Fitness = new()
    {
        Id = 33,
        Name = "Sports & Fitness",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Leisure,
        ParentTransactionCategoryId = Leisure.Id
    };

    public static readonly TransactionCategory Health = new()
    {
        Id = 34,
        Name = "Health",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Medication = new()
    {
        Id = 35,
        Name = "Medication",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Health,
        ParentTransactionCategoryId = Health.Id
    };

    public static readonly TransactionCategory DoctorExpenses = new()
    {
        Id = 36,
        Name = "Doctor Expenses",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Health,
        ParentTransactionCategoryId = Health.Id
    };

    public static readonly TransactionCategory Dental = new()
    {
        Id = 37,
        Name = "Dental Treatment",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Health,
        ParentTransactionCategoryId = Health.Id
    };

    public static readonly TransactionCategory Education = new()
    {
        Id = 38,
        Name = "Education & Training",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Courses = new()
    {
        Id = 39,
        Name = "Courses & Seminars",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Education,
        ParentTransactionCategoryId = Education.Id
    };

    public static readonly TransactionCategory Literature = new()
    {
        Id = 40,
        Name = "Professional Literature",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Education,
        ParentTransactionCategoryId = Education.Id
    };

    public static readonly TransactionCategory SchoolFees = new()
    {
        Id = 41,
        Name = "School Fees",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Education,
        ParentTransactionCategoryId = Education.Id
    };

    public static readonly TransactionCategory Retirement = new()
    {
        Id = 42,
        Name = "Retirement & Investments",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory Pension = new()
    {
        Id = 43,
        Name = "Pension Insurance",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Retirement,
        ParentTransactionCategoryId = Retirement.Id
    };

    public static readonly TransactionCategory PrivateRetirement = new()
    {
        Id = 44,
        Name = "Private Retirement Plan",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Retirement,
        ParentTransactionCategoryId = Retirement.Id
    };

    public static readonly TransactionCategory Securities = new()
    {
        Id = 45,
        Name = "Securities",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Retirement,
        ParentTransactionCategoryId = Retirement.Id
    };

    public static readonly TransactionCategory StockPurchases = new()
    {
        Id = 46,
        Name = "Stock Purchases",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Securities,
        ParentTransactionCategoryId = Securities.Id
    };

    public static readonly TransactionCategory ETFsFunds = new()
    {
        Id = 47,
        Name = "ETFs / Funds",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Securities,
        ParentTransactionCategoryId = Securities.Id
    };

    public static readonly TransactionCategory Crypto = new()
    {
        Id = 48,
        Name = "Cryptocurrencies",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Securities,
        ParentTransactionCategoryId = Securities.Id
    };

    public static readonly TransactionCategory P2P = new()
    {
        Id = 49,
        Name = "P2P Investments",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Retirement,
        ParentTransactionCategoryId = Retirement.Id
    };

    public static readonly TransactionCategory OtherInvestments = new()
    {
        Id = 50,
        Name = "Other Investments",
        Type = TransactionCategoryType.Expense,
        ParentCategory = Retirement,
        ParentTransactionCategoryId = Retirement.Id
    };

    public static readonly TransactionCategory OtherExpenses = new()
    {
        Id = 51,
        Name = "Other Expenses",
        Type = TransactionCategoryType.Expense
    };

    public static readonly TransactionCategory GiftsExpense = new()
    {
        Id = 52,
        Name = "Gifts",
        Type = TransactionCategoryType.Expense,
        ParentCategory = OtherExpenses,
        ParentTransactionCategoryId = OtherExpenses.Id
    };

    public static readonly TransactionCategory Donations = new()
    {
        Id = 53,
        Name = "Donations",
        Type = TransactionCategoryType.Expense,
        ParentCategory = OtherExpenses,
        ParentTransactionCategoryId = OtherExpenses.Id
    };

    public static readonly TransactionCategory Unexpected = new()
    {
        Id = 54,
        Name = "Unexpected Expenses",
        Type = TransactionCategoryType.Expense,
        ParentCategory = OtherExpenses,
        ParentTransactionCategoryId = OtherExpenses.Id
    };

    public static readonly IReadOnlyList<TransactionCategory> All = new[]
    {
        EarnedIncome, Salary, SideJob,
        SelfEmployment, SmallBusiness,
        InvestmentIncome, Interest, Dividends, StockSales,
        OtherIncome, GiftsIncome,
        Housing, Rent, Utilities, Electricity, InternetPhone,
        LivingExpenses, Groceries, Hygiene, Household,
        Mobility, PublicTransport, Car,
        Insurances, HealthInsurance, LiabilityInsurance, HouseholdInsurance, DisabilityInsurance,
        Leisure, Streaming, Hobbies, Travel, Fitness,
        Health, Medication, DoctorExpenses, Dental,
        Education, Courses, Literature, SchoolFees,
        Retirement, Pension, PrivateRetirement,
        Securities, StockPurchases, ETFsFunds, Crypto,
        P2P, OtherInvestments,
        OtherExpenses, GiftsExpense, Donations, Unexpected
    };
}