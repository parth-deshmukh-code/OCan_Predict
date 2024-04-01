namespace IntegrationTests.UseCases.Genders;

public class GetGenders : TestBase
{
    [Test]
    public async Task Get_WhenGendersAreObtained_ShouldReturnsOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}gender";
        var expectedGenders = GetGenderList();
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

    private static List<Gender> GetGenderList()
        =>
        [
            new() { Id = 1, Name = GenderName.Male },
            new() { Id = 2, Name = GenderName.Female }
        ];
}
