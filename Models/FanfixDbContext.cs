using Microsoft.EntityFrameworkCore;

namespace Fanfix.Models;

public class FanfixDbContext(DbContextOptions<FanfixDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadingList> ReadingLists => Set<ReadingList>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
          .HasMany(u => u.Fanfics)
          .WithOne(f => f.Creator)
          .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Fanfic>()
          .HasOne(f => f.Creator)
          .WithMany(c => c.Fanfics)
          .HasForeignKey(f => f.CreatorID)
          .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<ReadingList>()
          .HasMany(r => r.Fanfics)
          .WithMany(f => f.ReadingLists)
          .UsingEntity<ReadingListFanfic>(
              j => j.HasOne(rf => rf.Fanfic)
                    .WithMany()
                    .HasForeignKey(rf => rf.FanficID)
                    .OnDelete(DeleteBehavior.NoAction),
              j => j.HasOne(rf => rf.ReadingList)
                    .WithMany()
                    .HasForeignKey(rf => rf.ReadingListID)
                    .OnDelete(DeleteBehavior.NoAction));
    }
}