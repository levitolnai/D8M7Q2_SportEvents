using D8M7Q2_SportEvents.Entities;
using Microsoft.EntityFrameworkCore;

namespace D8M7Q2_SportEvents.Data
{
    public class SportEventContext: DbContext
    {
        public DbSet<SportEvent> SportEvents { get; set; }

        public DbSet<Competitor> Competitors { get; set; }

        public SportEventContext(DbContextOptions<SportEventContext> ctx)
            : base(ctx)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportEvent>()
                .HasMany(m => m.Competitors)
                .WithOne(r => r.SportEvent)
                .HasForeignKey(r => r.SportEventId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
