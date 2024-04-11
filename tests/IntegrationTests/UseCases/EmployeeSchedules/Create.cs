namespace IntegrationTests.UseCases.EmployeeSchedules;

public class CreateEmployeeSchedule : TestBase
{
    [Test]
    public async Task Post_WhenEmployeeScheduleIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}employee-schedule";
        var request = new CreateEmployeeScheduleRequest
        {
            EmployeeId = 1,
            WeekDayId = 1,
            MorningStartHour = new TimeSpan(7, 0, 0),
            MorningEndHour = new TimeSpan(12, 0, 0),
            AfternoonStartHour = new TimeSpan(13, 0, 0),
            AfternoonEndHour = new TimeSpan (17, 0, 0)
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(WeekDaySeeds.Get());
        await AddRangeAsync(OfficeSeeds.Get());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
        await AddRangeAsync(EmployeeSeeds.Get());

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
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}employee-schedule";
        var request = new CreateEmployeeScheduleRequest
        {
            EmployeeId = 1,
            WeekDayId = 1,
            MorningStartHour = null,
            MorningEndHour = null,
            AfternoonStartHour = null,
            AfternoonEndHour = null
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthenticated_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}employee-schedule";
        var request = new CreateEmployeeScheduleRequest();

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
        var requestUri = $"{TestSettings.BaseUri}employee-schedule";
        var request = new CreateEmployeeScheduleRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
