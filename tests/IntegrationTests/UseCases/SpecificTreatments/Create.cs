namespace IntegrationTests.UseCases.SpecificTreatments;

public class CreateSpecificTreatment : TestBase
{
    [Test]
    public async Task Post_WhenTreatmentIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}specific-treatment";
        var request = new CreateSpecificTreatmentRequest
        {
            Name = "Treatment",
            Price = 30,
            GeneralTreatmentId = 1
        };
        await AddRangeAsync(GeneralTreatmentSeeds.Get());

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
        var requestUri = $"{TestSettings.BaseUri}specific-treatment";
        var request = new CreateSpecificTreatmentRequest
        {
            Name = string.Empty,
            Price = 0,
            GeneralTreatmentId = 0
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
        var requestUri = $"{TestSettings.BaseUri}specific-treatment";
        var request = new CreateSpecificTreatmentRequest();

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
        var requestUri = $"{TestSettings.BaseUri}specific-treatment";
        var request = new CreateSpecificTreatmentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
