using Microsoft.EntityFrameworkCore;
using Server.Entityes;

namespace Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<FormData> Forms { get; set; }
    }
}
