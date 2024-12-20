

using BP215API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BP215API.DAL
{
    public class BP215APIDbContext : DbContext
    {
        public BP215APIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.HasIndex(x => x.Name)
                .IsUnique();
                b.Property(x => x.Name)
                .IsRequired().HasMaxLength(32);
                b.Property(x => x.Icon).HasMaxLength(128);
                b.HasData(new Language
                {
                    Code ="az",
                    Name = "Azərbaycan",
                    Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/2560px-Flag_of_Azerbaijan.svg.png"
                });
            });
            base.OnModelCreating(modelBuilder);
        }


    }
}
