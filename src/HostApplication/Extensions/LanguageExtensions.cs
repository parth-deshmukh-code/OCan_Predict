namespace DentallApp.HostApplication.Extensions;

public static class LanguageExtensions
{
    public static IServiceCollection ConfigureLanguages(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var languages = configuration
                .GetRequiredSection("Languages")
                .Get<string[]>() ?? [];

            List<CultureInfo> supportedCultures = [];
            foreach(var language in languages)
                supportedCultures.Add(new CultureInfo(language));

            var defaultLanguage = configuration.GetValue<string>("DefaultLanguage");
            options.DefaultRequestCulture = new RequestCulture(defaultLanguage);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        return services;
    }
}
