namespace IntegrationTests.UseCases.Kinships;

public class GetKinships : TestBase
{
    [Test]
    public async Task Get_WhenKinshipsAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}kinship";
        var expectedKinships = BaseSeeds.GetKinships();
        await AddRangeAsync(expectedKinships);

        // Act
        var httpResponse = await client.GetAsync(requestUri);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<List<Kinship>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEquivalentTo(expectedKinships);
    }
}
