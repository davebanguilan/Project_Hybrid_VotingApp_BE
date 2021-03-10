using Microsoft.EntityFrameworkCore;

namespace Votes.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=VotesDB;Integrated Security=True");
        }

    }
}
