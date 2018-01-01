namespace GameStoreApp.Data
{
   using Microsoft.EntityFrameworkCore;

   public class TemplateDbContext : DbContext
    {
      public DbSet<User> Users { get; set; }


       protected override void OnConfiguring(DbContextOptionsBuilder builder)
       {
          builder.UseSqlServer(@"Server=BALTSERVER\SQLEXPRESS;Database=TemplateDb;Integrated security=True");
       }

       protected override void OnModelCreating(ModelBuilder builder)
       {
          builder
             .Entity<User>()
             .HasIndex(u => u.Email)
             .IsUnique();
       }
   }
}
