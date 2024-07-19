using Microsoft.Extensions.DependencyInjection;
using TLbankRepositories.Interfaces;

namespace TLbankRepositories.MySQLRepository.Configurations;

public static partial class MyConfiguration
{
    public static IServiceCollection AddMyRepositories (this IServiceCollection builder)
    {
        builder.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
        builder.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.AddScoped<IContaRepository, ContaRepository>();
        return builder;
    }
}