namespace utgiftsoversikt.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        //public decimal Age { get; set; }
    
    public User() { Id = Guid.NewGuid().ToString(); }
    }
}