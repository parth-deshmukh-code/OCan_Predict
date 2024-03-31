namespace IntegrationTests.UseCases.Kinships;

public class GetKinshipsTest : TestBase
{
    [Test]
    public async Task Get_WhenKinshipsAreObtained_ShouldReturnsHttpStatusCodeOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = "/kinship";
        var expectedKinships = GetKinships();
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

    private static List<Kinship> GetKinships()
        =>
        [
            new() { Id = 1, Name = KinshipName.Spouse },
            new() { Id = 2, Name = KinshipName.Child },
            new() { Id = 3, Name = KinshipName.Other }
        ];
}
