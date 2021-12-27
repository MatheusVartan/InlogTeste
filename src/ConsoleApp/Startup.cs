using AppService.AppService;
using Dominio.Interfaces.AppService;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    public static class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("AppDbContext"));
                    services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
                    services.AddScoped<IVeiculoAppService, VeiculoAppService>();
                });
        }
    }
}