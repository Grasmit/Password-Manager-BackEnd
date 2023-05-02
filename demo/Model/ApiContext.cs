using Microsoft.EntityFrameworkCore;

namespace demo.Model
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UserDb");
        }

        public DbSet<Item> Items { get; set; }
    }

}
