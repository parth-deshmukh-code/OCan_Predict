namespace IntegrationTests.UseCases.Genders;

public class GetGenders : TestBase
{
    [Test]
    public async Task Get_WhenGendersAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}gender";
        var expectedGenders = BaseSeeds.GetGenders();
        await AddRangeAsync(expectedGenders);

        // Act
        var httpResponse = await client.GetAsync(requestUri);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<List<Gender>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEquivalentTo(expectedGenders);
    }
}
