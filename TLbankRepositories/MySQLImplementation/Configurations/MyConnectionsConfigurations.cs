using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TLbankRepositories.Contexts;

namespace TLbankRepositories.MySQLImplementantion.Configurations;

public static partial class MyConfigurations
{
    public static IServiceCollection AddMyConnection(this IServiceCollection builder, ConfigurationManager configuration)
    {
        var connectionString = "server=localhost,port=3306;database=TLbank;user=root;password=root"; //configuration.GetConnectionString("TLBKConnection");
        builder.AddDbContext<TLbankContext>(opts => 
            opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
/*         builder.AddDbContext<TLbankContext>(opts =>
            opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); */
        return builder;
    }       
}