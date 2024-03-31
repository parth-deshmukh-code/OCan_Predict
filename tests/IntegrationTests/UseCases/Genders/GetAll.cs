namespace IntegrationTests.UseCases.Genders;

public class GetGendersTest : TestBase
{
    [Test]
    public async Task Get_WhenGendersAreObtained_ShouldReturnsHttpStatusCodeOk()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = "/gender";
        var expectedGenders = GetGenders();
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

    private static List<Gender> GetGenders()
        =>
        [
            new() { Id = 1, Name = GenderName.Male },
            new() { Id = 2, Name = GenderName.Female }
        ];
}
