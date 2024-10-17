using Microsoft.Extensions.DependencyInjection;
using TLbankServices.Interfaces;
using TLbankServices.Implementations;

namespace TLbankServices.Configurations;

public static class MyServicesConfigurations
{
    public static IServiceCollection AddMyServices(this IServiceCollection builder)
    {
        builder.AddScoped<ITransferenciaService, TransferenciaService>();
        return builder;
    }
}