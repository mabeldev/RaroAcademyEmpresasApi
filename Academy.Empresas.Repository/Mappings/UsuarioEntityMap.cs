using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                prop => (RoleEnum)Enum.Parse(typeof(RoleEnum), prop)
            );

            builder.HasOne(prop => prop.Endereco).WithOne();
        }
    }
}