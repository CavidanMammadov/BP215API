

using BP215API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BP215API.DAL
{
    public class BP215APIDbContext : DbContext
    {
        public BP215APIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<WordForGame> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BP215APIDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
