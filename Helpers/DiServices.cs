namespace MyFirstApi.Helpers;

using MyFirstApi.Services;

public static class DiServices
{
    public static IServiceCollection AddDiServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostsService>();

        return services;
    }
}