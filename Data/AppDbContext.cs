using Gerenciador_de_Tarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Tarefas.Data;

public class AppDbContext : DbContext
{
    // 1. Criar as migrations -> dotnet ef migrations add Initial
    // 2. Update na database dotnet-ef database update
    
    public DbSet<TaskItem> Tasks { get; set; }

    // override Configuring -> Auto preenche
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KAYQUE-PC\\SQLEXPRESS; Initial Catalog=TaskManager;Integrated Security=true; TrustServerCertificate=True");
        
        base.OnConfiguring(optionsBuilder);
    }
}