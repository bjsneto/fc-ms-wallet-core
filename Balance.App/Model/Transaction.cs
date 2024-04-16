namespace Balance.App.Model
{
    public class Transaction : BaseEntity
    {
        public Transaction(Guid accountFromId, Guid accountToId, int amount)
        {
            Id = new Guid();
            AccountFromId = accountFromId;
            AccountToId = accountToId;
            Amount = amount;
            CreatedAt = DateTime.UtcNow;
        }
        public Guid AccountFromId { get; set; }
        public Guid AccountToId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
