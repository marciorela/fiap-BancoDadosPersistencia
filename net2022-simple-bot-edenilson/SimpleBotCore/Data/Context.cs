using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBotCore.Logic;

namespace SimpleBotCore.Data
{
    public class Context : DbContext
    {
        private IConfiguration _configuration; 
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(_configuration["AppConfig:SGBD"]));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimpleUser>().HasKey(x => x.Id);
            modelBuilder.Entity<SimpleUser>().Property(x => x.Id).HasMaxLength(50);
            
            modelBuilder.Entity<Message>().Property(x => x.Id).HasMaxLength(50);
        }

        public DbSet<SimpleUser> SimpleUsers { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
