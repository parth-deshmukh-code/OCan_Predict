namespace IntegrationTests.UseCases.AppointmentStatuses;

public class GetAppointmentStatuses : TestBase
{
    [Test]
    public async Task Get_WhenStatusesAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}appointment-status";
        var expectedStatuses = GetStatusList();
        await AddRangeAsync(expectedStatuses);

        // Act
        var httpResponse = await client.GetAsync(requestUri);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<List<AppointmentStatus>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEquivalentTo(expectedStatuses);
    }

    private static List<AppointmentStatus> GetStatusList()
        =>
        [
            new() { Id = 1, Name = StatusType.Scheduled },
            new() { Id = 2, Name = StatusType.NotAssisted },
            new() { Id = 3, Name = StatusType.Assisted },
            new() { Id = 4, Name = StatusType.Canceled }
        ];
}
