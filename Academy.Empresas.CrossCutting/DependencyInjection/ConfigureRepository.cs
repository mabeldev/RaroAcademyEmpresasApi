using Academy.Empresas.Domain.Interfaces.Repository;
using Academy.Empresas.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Empresas.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<IEmpresaRepository, EmpresaRepository>();
            serviceCollection.AddDbContext<EmpresasApiContext>(options => options.UseSqlServer(connectionString));
        }
    }
}