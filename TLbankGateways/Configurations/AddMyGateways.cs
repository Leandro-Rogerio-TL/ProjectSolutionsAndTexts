using Microsoft.Extensions.DependencyInjection;
using TLbankGateways.AutorizaGate.Implementations;
using TLbankGateways.AutorizaGate.Interfaces;
using TLbankGateways.NotifyGate.Implementations;
using TLbankGateways.NotifyGate.Interfaces;

namespace TLbankGateways.Configurations;

public static class MyGatewaysConfigurations
{
    public static IServiceCollection AddMyGateways(this IServiceCollection builder)
    {
        builder.AddScoped<IAutorizaGateware, AutorizaGateware>();
        builder.AddScoped<INotifyGateware, NotifyGateware>();
        return builder;
    }
}