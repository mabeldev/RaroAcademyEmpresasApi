using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Empresas.CrossCutting.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Empresas.CrossCutting.DependencyInjection
{
    public static class ConfigureMappers
    {
        public static void ConfigureDependenciesMapper(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cnf =>
            {
                cnf.AddProfile(new UsuarioEntityToContractMap());
                cnf.AddProfile(new EmpresaEntityToContractMap());
                cnf.AddProfile(new EnderecoEntityToContractMap());
            });

            var mapConfiguration = config.CreateMapper();
            serviceCollection.AddSingleton(mapConfiguration);
        }
    }
}