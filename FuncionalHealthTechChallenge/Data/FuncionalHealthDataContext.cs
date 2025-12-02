using FuncionalHealthTechChallenge.Data.Mapping;
using FuncionalHealthTechChallenge.Model;
using Microsoft.EntityFrameworkCore;

namespace FuncionalHealthTechChallenge.Data
{
    public class FuncionalHealthDataContext : DbContext
    {
        public FuncionalHealthDataContext(DbContextOptions<FuncionalHealthDataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
