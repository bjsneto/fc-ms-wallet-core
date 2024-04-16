namespace Balance.App.Model
{
    public class Account : BaseEntity
    {
        public Guid ClientId { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
