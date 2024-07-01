namespace DentallApp.HostApplication.Extensions;

public static class LanguageExtensions
{
    public static IServiceCollection ConfigureLanguages(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            List<CultureInfo> supportedCultures = [];
            var languages = configuration.GetLanguages();
            foreach (var language in languages)
                supportedCultures.Add(new CultureInfo(language));

            var defaultLanguage = configuration.GetDefaultLanguage();
            options.DefaultRequestCulture = new RequestCulture(defaultLanguage);
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        return services;
    }

    public static string[] GetLanguages(this IConfiguration configuration)
        => configuration
            .GetRequiredSection("Languages")
            .Get<string[]>() ?? [];

    public static string GetDefaultLanguage(this IConfiguration configuration)
        => configuration.GetValue<string>("DefaultLanguage") ?? "es";
}
