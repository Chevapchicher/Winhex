using Microsoft.EntityFrameworkCore;

namespace WinhexWebServer.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLog>()
                .HasMany(x => x.Logs)
                .WithOne(x => x.UserLog)
                .HasForeignKey(x => x.LogId);
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=sql307.hostingem.ru;UserId=gnioo_27156530;Password=udajutud;database=gnioo_27156530_main;");
        //}
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<UserAction> UserAction { get; set; }
    }
}