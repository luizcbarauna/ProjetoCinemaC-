using APICinema.Model;
using Microsoft.EntityFrameworkCore;

namespace APICinema.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Exemplo: relação 1:1 entre Usuario e Endereco
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Endereco>(e => e.UsuarioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
