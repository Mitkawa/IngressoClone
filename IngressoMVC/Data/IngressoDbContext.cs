using IngressoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace IngressoMVC.Data
{
    public class IngressoDbContext : DbContext
    {
        public IngressoDbContext(DbContextOptions<IngressoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtorFilme>().HasKey(af => new 
            {
                af.AtorId,
                af.FilmeId
            });

            modelBuilder.Entity<FilmeCategoria>().HasKey(af => new
            {
                af.FilmeId,
                af.CategoriaId
            });
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<AtorFilme> AtoresFilmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<FilmeCategoria> FilmesCategorias { get; set; }
        public DbSet<Produtor> Produtores { get; set; }
    }
}
