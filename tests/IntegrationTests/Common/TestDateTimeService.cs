namespace IntegrationTests.Common;

public class TestDateTimeService : IDateTimeService
{
    public DateTime Now
        => DateTime.Parse(EnvReader.Instance[TestSettings.CurrentDateTime]);

    public DateTime UtcNow => DateTime.UtcNow;
}
