using CasaPopular.API.Repository;
using CasaPopular.API.Repository.Interfaces;
using CasaPopular.API.Services;
using CasaPopular.API.Services.Interfaces;

namespace CasaPopular.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IRegraRepository, RegraRepository>();
            services.AddScoped<ICasaPopularService, CasaPopularService>();

        }
    }
}
