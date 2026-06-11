using Microsoft.EntityFrameworkCore;
using ReservaQuadra.Domain;

namespace ReservaQuadra.Context

{
    public class ReservaQuadraContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ReservaQuadraContext(DbContextOptions<ReservaQuadraContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
