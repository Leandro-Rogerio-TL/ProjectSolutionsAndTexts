using Microsoft.Extensions.DependencyInjection;

namespace TLbankInfra.ProblemDetailsCustomize;

public static class ProblemDetailsCustomize
{
    public static IServiceCollection AddProblemDetailsCustomize(IServiceCollection builder)
    {
        builder.AddProblemDetails(opts => opts.CustomizeProblemDetails = (context) =>
        {
            
        });
        return builder;
    }
}