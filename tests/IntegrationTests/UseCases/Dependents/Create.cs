namespace IntegrationTests.UseCases.Dependents;

public class CreateDependent : TestBase
{
    [Test]
    public async Task Post_WhenDependentIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}dependent";
        var request = new CreateDependentRequest
        {
            Document = "0923611733",
            Names = "Roberto Junior",
            LastNames = "Placencio Pinto",
            CellPhone = "0953581040",
            DateBirth = new DateTime(2010, 08, 27),
            Email = "basic_user@hotmail.com",
            GenderId = 1,
            KinshipId = 2
        };
        await CreateSeedData();

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
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}dependent";
        var request = new CreateDependentRequest
        {
            Document = string.Empty,
            Names = string.Empty,
            LastNames = string.Empty,
            CellPhone = string.Empty,
            DateBirth = null,
            Email = string.Empty,
            KinshipId = 0
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
        var requestUri = $"{TestSettings.BaseUri}dependent";
        var request = new CreateDependentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenClientIsNotBasicUser_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}dependent";
        var request = new CreateDependentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

    private async Task CreateSeedData()
    {
        await AddRangeAsync(BaseSeeds.GetKinships());
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
    }
}
