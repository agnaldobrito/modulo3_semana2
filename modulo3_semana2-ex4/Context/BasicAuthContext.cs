using Microsoft.EntityFrameworkCore;
using modulo3_semana2_ex4.Models;
using modulo3_semana2_ex4.Seeds;

namespace modulo3_semana2_ex4.Data
{
    public class BasicAuthContext : DbContext
    {
        public BasicAuthContext()
        {

        }
        public BasicAuthContext(DbContextOptions<BasicAuthContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(UserSeeds.usuarioSeed);
        }
    }
}
