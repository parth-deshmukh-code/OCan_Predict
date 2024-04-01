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
        var persons = GetPersonList();
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
        await AddAsync(new Gender { Id = 1, Name = GenderName.Male });
        await AddRangeAsync(persons);

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
        var persons = GetPersonList();
        await AddAsync(new Gender { Id = 1, Name = GenderName.Male });
        await AddRangeAsync(persons);

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

    private static List<Person> GetPersonList()
        =>
        [
            new() 
            { 
                Id = 1,
                Document = "0923611701",
                Names = "David Sebastian",
                LastNames = "Roman Amariles",
                CellPhone = "0953581032",
                Email = "dave123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            },
            new()
            {
                Id = 2,
                Document = "0923611733",
                Names = "Roberto Emilio",
                LastNames = "Placencio Pinto",
                CellPhone = "0953581040",
                Email = "roberto123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            },
            new()
            {
                Id = 3,
                Document = "0923611744",
                Names = "Guillermo Emilio",
                LastNames = "Rivera Pinto",
                CellPhone = "0953581060",
                Email = "guillermo123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            }
        ];
}
