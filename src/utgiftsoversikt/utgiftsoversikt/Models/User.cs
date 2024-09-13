namespace utgiftsoversikt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public bool Is_admin { get; set; }
    }
}