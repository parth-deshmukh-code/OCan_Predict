namespace IntegrationTests.UseCases.OfficeSchedules;

public class CreateOfficeSchedule : TestBase
{
    [Test]
    public async Task Post_WhenOfficeScheduleIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}office-schedule";
        var request = new CreateOfficeScheduleRequest
        {
            WeekDayId = 1,
            OfficeId = 1,
            StartHour = new TimeSpan(7, 0, 0),
            EndHour = new TimeSpan(17, 0, 0)
        };
        await AddRangeAsync(OfficeSeeds.Get());
        await AddRangeAsync(WeekDaySeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<CreatedId>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Data.Id.Should().Be(expectedId);
    }

    [Test]
    public async Task Post_WhenRequestIsInvalid_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}office-schedule";
        var request = new CreateOfficeScheduleRequest
        {
            WeekDayId = -1,
            OfficeId = -1,
            StartHour = new TimeSpan(17, 0, 0),
            EndHour = new TimeSpan(7, 0, 0)
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenAdminIsNotAssignedToOffice_ShouldReturnsForbidden()
    {
        // Arrange
        var expectedMessage = Messages.OfficeNotAssigned;
        var client = CreateClientAsAdmin();
        var requestUri = $"{TestSettings.BaseUri}office-schedule";
        var request = new CreateOfficeScheduleRequest
        {
            WeekDayId = 1,
            OfficeId = 2,
            StartHour = new TimeSpan(7, 0, 0),
            EndHour = new TimeSpan(17, 0, 0)
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<CreatedId>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthenticated_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}office-schedule";
        var request = new CreateOfficeScheduleRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthorized_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}office-schedule";
        var request = new CreateOfficeScheduleRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
