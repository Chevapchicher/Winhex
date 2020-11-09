using Microsoft.EntityFrameworkCore;

namespace WinhexWebServer.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<UserLog> UserLog { get; set; }
    }
}