using ativa_recife.events;
using Microsoft.EntityFrameworkCore;

namespace ativa_recife.data;

public class AppDBContext : DbContext
{
     public DbSet<Event> Event { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseSqlite("Data Source=eventdb.sqlite");
          optionsBuilder.LogTo(Console.WriteLine);
          
          base.OnConfiguring(optionsBuilder);
     }
}