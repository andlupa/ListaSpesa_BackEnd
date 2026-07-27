using Microsoft.EntityFrameworkCore;

namespace MiaApiLocale
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Libro> Libri {  get; set; }
    }
}
