using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dominio.DB.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Curso.Dominio;Integrated Security=true");
            }
        }

        public DbSet<CursoXunit.Dominio.Cursos.Curso> Cursos { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
