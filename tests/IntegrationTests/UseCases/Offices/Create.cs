namespace IntegrationTests.UseCases.Offices;

public class CreateOffice : TestBase
{
    [Test]
    public async Task Post_WhenOfficeIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}office";
        var request = new CreateOfficeRequest
        {
            Name = "ALBORADA",
            Address = "ALBORADA",
            ContactNumber = "0980852228"
        };

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
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}office";
        var request = new CreateOfficeRequest
        {
            Name = string.Empty,
            Address = string.Empty,
            ContactNumber = string.Empty
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
        var requestUri = $"{TestSettings.BaseUri}office";
        var request = new CreateOfficeRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenClientIsNotSuperadmin_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsDentist();
        var requestUri = $"{TestSettings.BaseUri}office";
        var request = new CreateOfficeRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
