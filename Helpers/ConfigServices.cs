namespace MyFirstApi.Helpers;

public static class ConfigServices
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //one conf value
        services.Configure<DataBaseOption>(configuration.GetSection(DataBaseOption.SectionName));

        //multiple confs
        services.Configure<DataBaseOption>(DataBaseOption.SystemDatabaseSectionName,
            configuration.GetSection($"{DataBaseOption.SectionNameMultipleConf}:{DataBaseOption.SystemDatabaseSectionName}"));
        services.Configure<DataBaseOption>(DataBaseOption.BusinessDatabaseSectionName,
            configuration.GetSection($"{DataBaseOption.SectionNameMultipleConf}:{DataBaseOption.BusinessDatabaseSectionName}"));

        return services;
    }
}