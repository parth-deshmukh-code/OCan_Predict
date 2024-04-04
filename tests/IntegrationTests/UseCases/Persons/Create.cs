namespace IntegrationTests.UseCases.Persons;

public class CreatePerson : TestBase
{
    [Test]
    public async Task Post_WhenPersonIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}person";
        var request = new CreatePersonRequest
        {
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 01, 01),
            Email = "secretary@hotmail.com",
            GenderId = 1
        };
        await AddRangeAsync(BaseSeeds.GetGenders());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}person";
        var request = new CreatePersonRequest
        {
            Document = string.Empty,
            Names = string.Empty,
            LastNames = string.Empty,
            CellPhone = string.Empty,
            DateBirth = null,
            Email = string.Empty
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthorized_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}person";
        var request = new CreatePersonRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
