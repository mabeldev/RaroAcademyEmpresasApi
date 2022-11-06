using Academy.Empresas.Domain.Entities;
using Academy.Empresas.Domain.Enum;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Empresas.Repository.Mappings
{
    public class UsuarioEntityMap
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.Property(prop => prop.Role).HasConversion(
                                prop => prop.ToString(),
                                    prop => (RoleEnum)Enum.Parse
                                        (typeof(RoleEnum), prop)
            );

            builder.HasIndex(prop => prop.Email).IsUnique();
            
            builder.HasIndex(prop => prop.CPF).IsUnique();

            builder.HasOne(prop => prop.Endereco).WithOne();
        }
    }
}