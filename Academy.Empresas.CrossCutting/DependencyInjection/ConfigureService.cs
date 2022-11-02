using Academy.Empresas.Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Empresas.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            // serviceCollection.AddScoped<IUsuarioService, UsuarioService>();
            // serviceCollection.AddScoped<IEmpresaService, EmpresaService>();
            // serviceCollection.AddScoped<IAutenticacaoService, AutenticacaoService>();
        }
    }
}