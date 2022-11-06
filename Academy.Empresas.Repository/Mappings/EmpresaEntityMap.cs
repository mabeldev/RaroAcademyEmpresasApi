using Academy.Empresas.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Empresas.Repository.Mappings
{
    public class EmpresaEntityMap
    {
        public void Configure(EntityTypeBuilder<EmpresaEntity> builder)
        {
            builder.HasOne(prop => prop.Endereco).WithOne();
        }
    }
}