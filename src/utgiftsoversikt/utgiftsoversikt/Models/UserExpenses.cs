namespace utgiftsoversikt.Models
{
    public class UserExpenses
    {
        public string Id { get; set; } //Referer til en user.Id for aktuell bruker
        public List<MonthlyExpenses> Months { get; set; }
        

        public UserExpenses() { }
    }
}
