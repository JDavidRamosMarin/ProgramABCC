using ABCCProgram.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ABCCProgram
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Familia> Familias { get; set; }
    }
}
