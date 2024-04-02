namespace IntegrationTests.Common;

/// <summary>
/// This implementation is for testing purposes only and serves to avoid dependence on the system clock.
/// </summary>
public class TestDateTimeService : IDateTimeService
{
    /// <summary>
    /// The developer must set the environment variable called <see cref="TestSettings.CurrentDateTime"/> 
    /// in the integration tests that depend on the system clock.
    /// </summary>
    public DateTime Now
    {
        get
        {
            IEnvReader envVars = EnvReader.Instance;
            string currentDateTime = envVars[TestSettings.CurrentDateTime];
            return DateTime.Parse(currentDateTime);
        }
    }

    public DateTime UtcNow => DateTime.UtcNow;
}
