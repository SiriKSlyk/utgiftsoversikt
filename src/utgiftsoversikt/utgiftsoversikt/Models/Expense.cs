﻿using System.ComponentModel;

namespace utgiftsoversikt.Models
{
    public class Expense
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Month { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Shop { get; set; }
        public string Category { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; } = "No description given";
    }
}