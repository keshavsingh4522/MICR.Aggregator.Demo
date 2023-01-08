

using MICR.Services.User.API;

namespace MICR.Services.Users.API.Extensions;

/// <summary>
/// 
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcClientServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddGrpcClient<UserService.UserServiceClient>("UserGrpcV1", o =>
        {
            o.Address = new Uri(config["GrpcServiceEndpoints:MICR.Services.User"]);
        });

        return services;
    }
}
