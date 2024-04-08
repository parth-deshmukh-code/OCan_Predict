namespace IntegrationTests.UseCases.PublicHolidays;

public class CreatePublicHoliday : TestBase
{
    [TestCaseSource(nameof(OfficesIdTest))]
    public async Task Post_WhenPublicHolidayIsCreated_ShouldReturnsCreated(List<int> officesId)
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}public-holiday";
        var request = new CreatePublicHolidayRequest
        {
            Description = "Test",
            Day = 01,
            Month = 02,
            OfficesId = officesId
        };
        await AddRangeAsync(OfficeSeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<CreatedId>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Data.Id.Should().Be(expectedId);
    }

    static IEnumerable<List<int>> OfficesIdTest()
    {
        yield return [1, 2, 3];
        yield return [1, 2];
        yield return [1];
        yield return [1, 1, 1];
        yield return [1, 2, 1];
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}public-holiday";
        var request = new CreatePublicHolidayRequest
        {
            Description = string.Empty,
            Day = 01,
            Month = 02,
            OfficesId = []
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
        var requestUri = $"{TestSettings.BaseUri}public-holiday";
        var request = new CreatePublicHolidayRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenClientIsNotSuperadmin_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}public-holiday";
        var request = new CreatePublicHolidayRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
