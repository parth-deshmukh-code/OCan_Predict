namespace IntegrationTests.UseCases.FavoriteDentists;

public class CreateFavoriteDentist : TestBase
{
    [Test]
    public async Task Post_WhenFavoriteDentistIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}favorite-dentist";
        var request = new CreateFavoriteDentistRequest
        {
            DentistId = 4
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
        await AddRangeAsync(OfficeSeeds.Get());
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

    [TestCase(0)]
    [TestCase(-1)]
    public async Task Post_WhenDentistIdIsLessThanOrEqualToZero_ShouldReturnsBadRequest(int dentistId)
    {
        // Arrange
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}favorite-dentist";
        var request = new CreateFavoriteDentistRequest
        {
            DentistId = dentistId
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
        var requestUri = $"{TestSettings.BaseUri}favorite-dentist";
        var request = new CreateFavoriteDentistRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenClientIsNotBasicUser_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsDentist();
        var requestUri = $"{TestSettings.BaseUri}favorite-dentist";
        var request = new CreateFavoriteDentistRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
