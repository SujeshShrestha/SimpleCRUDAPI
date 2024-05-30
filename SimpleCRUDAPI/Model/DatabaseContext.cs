using Microsoft.EntityFrameworkCore;

namespace SimpleCRUDAPI.Model
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {


        }
        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
