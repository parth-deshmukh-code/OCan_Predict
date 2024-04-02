namespace IntegrationTests.UseCases.Kinships;

public class GetKinships : TestBase
{
    [Test]
    public async Task Get_WhenKinshipsAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}kinship";
        var expectedKinships = GetKinshipList();
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

    private static List<Kinship> GetKinshipList()
        =>
        [
            new() { Id = 1, Name = KinshipName.Spouse },
            new() { Id = 2, Name = KinshipName.Child },
            new() { Id = 3, Name = KinshipName.Other }
        ];
}
