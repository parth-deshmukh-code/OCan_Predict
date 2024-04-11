namespace IntegrationTests.UseCases.Security.Users;

public class CreateUser : TestBase
{
    [Test]
    public async Task Post_WhenUserIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user";
        var request = new CreateBasicUserRequest
        {
            UserName = "user_test@hotmail.com",
            Password = "Dsr2877565716",
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 05, 01),
            GenderId = 1
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(RoleSeeds.GetRoles());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var user = await FindAsync<User>(expectedId);

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        user.Id.Should().Be(expectedId);
        user.UserName.Should().Be(request.UserName);
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user";
        var request = new CreateBasicUserRequest
        {
            UserName = string.Empty,
            Password = string.Empty,
            Document = string.Empty,
            Names = string.Empty,
            LastNames = string.Empty,
            CellPhone = string.Empty,
            DateBirth = null
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenUserNameExists_ShouldReturnsConflict()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user";
        var request = new CreateBasicUserRequest
        {
            UserName = "basic_user@hotmail.com",
            Password = "Dsr2877565716",
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 05, 01),
            GenderId = 1
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }
}
