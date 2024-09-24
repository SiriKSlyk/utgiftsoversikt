namespace utgiftsoversikt.Models
{
    public class Month
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string MonthYear { get; set; } // MMYYYY
        public string BudgetId { get; set; }
        public decimal House { get; set; } = 0M;
        public decimal Food { get; set; } = 0M;
        public decimal Transport { get; set; } = 0M;
<<<<<<< HEAD
=======
        public decimal Cloths { get; set; } = 0M;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        public decimal Debt { get; set; } = 0M;
        public decimal Saving { get; set; } = 0M;
        public decimal Etc { get; set; } = 0M;
        public decimal Sum { get; set; } = 0M;

    }
}
