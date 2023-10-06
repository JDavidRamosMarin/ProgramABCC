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
    }
}
