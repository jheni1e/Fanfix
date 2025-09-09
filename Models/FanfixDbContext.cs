using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
          .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Fanfic>()
          .HasOne(f => f.Creator)
          .HasForeignKey(f => f.CreatorID)
          .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<ReadingList>()
          .HasMany(r => r.Fanfics)
          .OnDelete(DeleteBehavior.NoAction);
    }
}