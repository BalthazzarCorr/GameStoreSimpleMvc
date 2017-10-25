namespace MyGameStoreApp.Data
{
   using EntityModels;
   using Microsoft.EntityFrameworkCore;

   public class GameStoreDbContext : DbContext
    {

       public DbSet<User> Users { get; set; }

       public DbSet<Game> Games { get; set; }

      public  DbSet<Order> Orders { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder builder)
       {
          builder
            .UseSqlServer("Server=.;Database=MyGameStoreDb;Integrated security=True;");
       }

       protected override void OnModelCreating(ModelBuilder builder)
       {
          builder.Entity<User>().HasIndex(u => u.Email).IsUnique();

          builder.Entity<Order>().HasKey(o => new {o.UserId, o.GameId});

          builder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(u => u.UserId);

          builder.Entity<Order>().HasOne(o => o.Game).WithMany(u => u.Orders).HasForeignKey(u => u.GameId);
       }

    }
}
