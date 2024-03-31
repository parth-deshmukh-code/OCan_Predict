namespace IntegrationTests.Common;

public partial class TestBase
{
    private CustomWebApplicationFactory _webApplicationFactory;
    protected CustomWebApplicationFactory ApplicationFactory => _webApplicationFactory;

    /// <summary>
    /// Initializes the web application before starting tests for a class.
    /// </summary>
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
        => _webApplicationFactory = new CustomWebApplicationFactory();

    /// <summary>
    /// Frees resources upon completion of all tests in a class.
    /// </summary>
    [OneTimeTearDown]
    public void RunAfterAnyTests()
        => _webApplicationFactory.Dispose();

    /// <summary>
    /// Creates the database before starting a test.
    /// </summary>
    /// <remarks>The database is only created if it does not exist.</remarks>
    [SetUp]
    public void Init()
    {
        using var serviceScope = _webApplicationFactory.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        context.Database.EnsureCreated();
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, string.Empty);
    }

    /// <summary>
    /// Deletes the data from each table after the test is completed.
    /// </summary>
    [TearDown]
    public async Task CleanUp()
    {
        var settings = new EnvBinder().Bind<DatabaseSettings>();
        var builder = new MySqlConnectionStringBuilder
        {
            UserID   = settings.DbUserName, 
            Password = settings.DbPassword,
            Port     = settings.DbPort,
            Server   = settings.DbHost,
            Database = settings.DbDatabase
        };
        using var connection = new MySqlConnection(builder.ConnectionString);
        await connection.OpenAsync();
        var respawner = await Respawner.CreateAsync(connection, new RespawnerOptions
        {
            SchemasToInclude =
            [
                settings.DbDatabase
            ],
            DbAdapter = DbAdapter.MySql,
            WithReseed = true
        });
        await respawner.ResetAsync(connection);
    }
}
