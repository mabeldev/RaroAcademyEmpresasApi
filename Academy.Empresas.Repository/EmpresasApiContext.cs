using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Academy.Empresas.Repository
{
    public class EmpresasApiContext : DbContext
    {
        public EmpresasApiContext() { }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EmpresaEntity> Empresas { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }

        public EmpresasApiContext(DbContextOptions<EmpresasApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>(new UsuarioEntityMap().Configure);
            modelBuilder.Entity<EmpresaEntity>(new EmpresaEntityMap().Configure);
        }
    }
}