using CompartilhandoCalorHumano_Uninter.Models;
using Microsoft.EntityFrameworkCore;

namespace CompartilhandoCalorHumano_Uninter.ContextDb
{
    public class Context : DbContext
    {
        public Context() { }

        public DbSet<Cadastro> Cadastros { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CompartilhandoCalorHumano;Trusted_Connection=true;");
        }
    }
}
