using Academy.Empresas.Domain.Interfaces.Service;
using Academy.Empresas.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Empresas.CrossCutting.DependencyInjection
{
    public static class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsuarioService, UsuarioService>();
            serviceCollection.AddScoped<IEmpresaService, EmpresaService>();
            serviceCollection.AddScoped<IAutenticacaoService, AutenticacaoService>();
        }
    }
}