﻿using Finance_Api.Core.Enums;

namespace Finance_Api.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
