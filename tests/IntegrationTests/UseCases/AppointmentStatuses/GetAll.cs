namespace IntegrationTests.UseCases.AppointmentStatuses;

public class GetAppointmentStatuses : TestBase
{
    [Test]
    public async Task Get_WhenStatusesAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}appointment-status";
        var expectedStatuses = BaseSeeds.GetAppointmentStatuses();
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
}
