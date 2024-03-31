namespace IntegrationTests.Common;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        // First ".env.test" is loaded and then ".env" but the key values of .env.test are not overridden.
        new EnvLoader()
            .EnableFileNotFoundException()
            .AddEnvFile(".env.test")
            .Load();

        builder.ConfigureServices(services =>
        {
            var dateTimeProviderDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(IDateTimeService));

            services.Remove(dateTimeProviderDescriptor);
            services.AddSingleton<IDateTimeService, TestDateTimeService>();
        });
    }
}
