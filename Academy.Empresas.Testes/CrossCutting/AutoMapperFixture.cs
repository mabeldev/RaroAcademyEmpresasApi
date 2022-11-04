using Academy.Empresas.CrossCutting.Mappers;
using AutoMapper;

namespace Academy.Empresas.Testes.CrossCutting
{
    public abstract class BaseAutoMapperFixture
    {
        public IMapper mapper { get; set; }

        public BaseAutoMapperFixture()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsuarioEntityToContractMap());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}