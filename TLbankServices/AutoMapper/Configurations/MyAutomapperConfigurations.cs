using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TLbankServices.AutoMapper.Configurations;

public static class MyAutomapperConfigurations
{
    public static IServiceCollection AddMyAutomapper(this IServiceCollection builder)
    {
        builder.AddAutoMapper(Assembly.GetExecutingAssembly());
        return builder;
    }
}