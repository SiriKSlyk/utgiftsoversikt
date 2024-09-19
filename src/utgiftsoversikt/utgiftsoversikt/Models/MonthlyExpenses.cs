namespace utgiftsoversikt.Models
{
    public class MonthlyExpenses
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Month { get; set; }
        public List<Expense>? Expenses { get; set; }
        public decimal? House { get; set; } = 0M;
        public decimal? Food { get; set; } = 0M;
        public decimal? Transport { get; set; } = 0M;
        public decimal? Debt { get; set; } = 0M;
        public decimal? Saving { get; set; } = 0M;
        public decimal? Etc { get; set; } = 0M;
        public decimal? Subscriptions { get; set; } = 0M;
        public string? BudgetId { get; set; }

        public MonthlyExpenses() { }
    }
}
