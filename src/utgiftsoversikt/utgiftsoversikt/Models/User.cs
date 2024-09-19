﻿namespace utgiftsoversikt.Models
{
    public class User
    {
        public string? Id { get; set; }
        public List<Expense>? Expenses { get; set; }
        public string? Email {  get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public bool? Is_admin { get; set; }
    
    public User() { Id = Guid.NewGuid().ToString(); Is_admin = false; }
    }
}