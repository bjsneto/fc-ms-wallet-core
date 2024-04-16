
namespace Balance.App.Model
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }  
        public string Email { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
