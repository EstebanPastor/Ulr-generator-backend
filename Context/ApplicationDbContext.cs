using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Video> Videos { get; set; }
    }
}
