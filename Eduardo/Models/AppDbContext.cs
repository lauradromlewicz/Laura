using Microsoft.EntityFrameworkCore;

namespace Eduardo.Models;


public class AppDbContext : DbContext {

   public DbSet<Funcionario> Funcionarios { get; set; }
   public DbSet<Folha> Folhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlite("Data Source=laura1_eduardo2.db");
    }
}





