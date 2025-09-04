using Finance_Api.Core.Enums;

namespace Finance_Api.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
