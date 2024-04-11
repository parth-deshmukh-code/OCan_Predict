namespace IntegrationTests.UseCases.GeneralTreatments;

public class CreateGeneralTreatment : TestBase
{
    [Test]
    public async Task Post_WhenGeneralTreatmentIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var appSettings = ApplicationFactory.Services.GetRequiredService<AppSettings>();
        var requestUri = $"{TestSettings.BaseUri}general-treatment";
        var request = new CreateGeneralTreatmentRequest
        {
            Name = "Orthodontics",
            Description = "Orthodontics",
            Duration = 10
        };
        var filePath = Path.Combine(appSettings.DentalServicesImagesPath, "teeth.png");
        var fileName = Path.GetFileName(filePath);
        using var multipartContent = new MultipartFormDataContent();
        using var fileStream = new FileStream(filePath, FileMode.Open);
        var streamContent = new StreamContent(fileStream);
        streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        multipartContent.Add(new StringContent(request.Name), nameof(request.Name));
        multipartContent.Add(new StringContent(request.Description), nameof(request.Description));
        multipartContent.Add(new StringContent(request.Duration.ToString()), nameof(request.Duration));
        multipartContent.Add(streamContent, nameof(request.Image), fileName);

        // Act
        var httpResponse = await client.PostAsync(requestUri, multipartContent);
        var treatment = await FindAsync<GeneralTreatment>(expectedId);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<CreatedId>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Data.Id.Should().Be(expectedId);
        var imageUrl = Path.Combine(appSettings.DentalServicesImagesPath, treatment.ImageUrl);
        File.Exists(imageUrl).Should().BeTrue();
        File.Delete(imageUrl);
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}general-treatment";
        var request = new CreateGeneralTreatmentRequest
        {
            Name = string.Empty,
            Description = string.Empty,
            Duration = 0,
            Image = null
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
        var requestUri = $"{TestSettings.BaseUri}general-treatment";
        var request = new CreateGeneralTreatmentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenClientIsNotSuperadmin_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}general-treatment";
        var request = new CreateGeneralTreatmentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
