using Microsoft.EntityFrameworkCore;
using Balance.App.Model;

namespace Balance.App.Data
{
    public class BalanceDbContext : DbContext
    {
        public BalanceDbContext(DbContextOptions<BalanceDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"),
                    Email = "belarmino@mail.com",
                    Name = "Belarmino"
                },
                new Client
                {
                    Id = Guid.Parse("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"),
                    Email = "neto@mail.com",
                    Name = "Neto"
                }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.Parse("d95f9fc4-3cf4-49e9-afd9-007da4653f4a"),
                    ClientId = Guid.Parse("4cf4c747-8b7e-4520-92bd-431e64b2ab4c"),
                    Balance = 100000
                },
                new Account
                {
                    Id = Guid.Parse("1232b62f-5b34-4b8a-9f7a-1a349390a353"),
                    ClientId = Guid.Parse("ba7f96dc-3b7a-4d78-84f6-4756ad4bfb74"),
                    Balance = 10
                }
            );
        }
    }
}
