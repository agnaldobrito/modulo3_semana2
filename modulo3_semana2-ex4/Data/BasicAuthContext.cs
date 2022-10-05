using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using modulo3_semana2_ex4.Models;

namespace modulo3_semana2_ex4.Data
{
    public class BasicAuthContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BasicAuthContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DB_connect")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entidade =>
            {
                entidade.ToTable("Usuarios");

                entidade.HasKey(a => a.Id);
                entidade.HasAlternateKey(a => a.NomeUsuario);

                entidade
                    .Property(a => a.NomeUsuario)
                    .HasMaxLength(120)
                    .IsRequired();

                entidade
                    .Property(a => a.Senha)
                    .HasMaxLength(100)
                    .IsRequired();

                entidade.HasData(
                    new Usuario
                    {
                        Id = Guid.Parse("3ff37ac0-75bb-4dc9-9cc8-b5259d01088a"),
                        NomeUsuario = "admin",
                        Senha = "123abc456"
                    }
                );
            });
        }
    }
}
