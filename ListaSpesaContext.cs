using ListaSpesa_BackEnd;
using Microsoft.EntityFrameworkCore;

namespace ListaSpesa_BackEnd
{
    public class ListaSpesaContext : DbContext
    {
        public ListaSpesaContext(DbContextOptions<ListaSpesaContext> options)
            : base(options) { }

        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Articolo> Articoli { get; set; }
    }
}
