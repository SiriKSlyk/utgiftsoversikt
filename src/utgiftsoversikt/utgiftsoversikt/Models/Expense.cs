using System.ComponentModel;

namespace utgiftsoversikt.Models
{
    public class Expense
    {
        public string? Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Shop { get; set; }
        public string? Category { get; set; }
        public decimal Sum { get; set; }
        public string? Description { get; set; }

        public Expense() { Id = Guid.NewGuid().ToString(); }
    }
}