using Microsoft.EntityFrameworkCore;
using Registro_Completo.Entidades;

namespace Registro_Completo.DAL{

public class Contexto : DbContext{
    public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source = DPersonas.db");
        }

    
    }

}