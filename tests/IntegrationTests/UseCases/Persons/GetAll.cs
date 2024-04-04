namespace IntegrationTests.UseCases.Persons;

public class GetPersons : TestBase
{
    [TestCase("Roberto Emilio")]
    [TestCase("ROBERTO EMILIO")]
    [TestCase("Placencio Pinto")]
    [TestCase("PLACENCIO PINTO")]
    [TestCase("0923611733")]
    public async Task Get_WhenPersonsAreObtained_ShouldReturnsOk(string valueToSearch)
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}person/search?value={valueToSearch}";
        var expectedPersons = new List<GetPersonsResponse>()
        {
            new()
            {
                PersonId = 2,
                Document = "0923611733",
                Names = "Roberto Emilio",
                LastNames = "Placencio Pinto",
                FullName = "Roberto Emilio Placencio Pinto",
                CellPhone = "0953581040",
                Email = "roberto123@hotmail.com"
            }
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(PersonSeeds.GetPersons());

        // Act
        var httpResponse = await client.GetAsync(requestUri);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<List<GetPersonsResponse>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEquivalentTo(expectedPersons);
    }

    [TestCase("Roberto123")]
    [TestCase("Placencio123")]
    public async Task Get_WhenThereAreNoResults_ShouldReturnsEmptyList(string valueToSearch)
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}person/search?value={valueToSearch}";
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(PersonSeeds.GetPersons());

        // Act
        var httpResponse = await client.GetAsync(requestUri);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<List<GetPersonsResponse>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().BeEmpty();
    }

    [Test]
    public async Task Get_WhenUserIsNotAuthorized_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}person/search?value=test";

        // Act
        var httpResponse = await client.GetAsync(requestUri);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
