namespace IntegrationTests.UseCases.Security.Employees;

public class CreateEmployee : TestBase
{
    [TestCaseSource(typeof(EmployeeTestCases))]
    public async Task Post_WhenEmployeeIsCreated_ShouldReturnsCreated(
        List<int> rolesId, 
        List<int> specialtiesId)
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest
        {
            UserName = "user_test@hotmail.com",
            Password = "Dsr2788565720",
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 01, 01),
            GenderId = 1,
            OfficeId = 1,
            PregradeUniversity = "UG",
            PostgradeUniversity = "ESPOL",
            Roles = rolesId,
            SpecialtiesId = specialtiesId
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(RoleSeeds.GetRoles());
        await AddRangeAsync(OfficeSeeds.Get());
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

    class EmployeeTestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<int>() { (int)Role.Predefined.Secretary },
                new List<int>()
            };

            yield return new object[]
            {
                new List<int>()
                {
                    (int)Role.Predefined.Secretary,
                    (int)Role.Predefined.Dentist
                },
                new List<int>() { 1 }
            };

            yield return new object[]
            {
                new List<int>()
                {
                    (int)Role.Predefined.Secretary,
                    (int)Role.Predefined.Dentist,
                    (int)Role.Predefined.Admin
                },
                new List<int>() { 1, 2 }
            };
        }
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest
        {
            UserName = string.Empty,
            Password = string.Empty,
            Document = string.Empty,
            Names = string.Empty,
            LastNames = string.Empty,
            CellPhone = string.Empty,
            DateBirth = null,
            GenderId = 1,
            OfficeId = 1,
            PregradeUniversity = string.Empty,
            PostgradeUniversity = string.Empty,
            Roles = [],
            SpecialtiesId = []
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenUserNameExists_ShouldReturnsConflict()
    {
        // Arrange
        var client = CreateClientAsSuperadmin();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest
        {
            UserName = "dentist@hotmail.com",
            Password = "Dsr2788565720",
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 01, 01),
            GenderId = 1,
            OfficeId = 1,
            PregradeUniversity = "UG",
            PostgradeUniversity = "ESPOL",
            Roles = [(int)Role.Predefined.Secretary],
            SpecialtiesId = []
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(RoleSeeds.GetRoles());
        await AddRangeAsync(OfficeSeeds.Get());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
        await AddRangeAsync(EmployeeSeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Test]
    public async Task Post_WhenAdminIsNotAssignedToOffice_ShouldReturnsForbidden()
    {
        // Arrange
        var expectedMessage = Messages.OfficeNotAssigned;
        var client = CreateClientAsAdmin();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest
        {
            UserName = "admin_test@hotmail.com",
            Password = "Dsr2788565720",
            Document = "0923611701",
            Names = "David Sebastian",
            LastNames = "Roman Amariles",
            CellPhone = "0953581032",
            DateBirth = new DateTime(1997, 01, 01),
            GenderId = 1,
            OfficeId = 2,
            PregradeUniversity = "UG",
            PostgradeUniversity = "ESPOL",
            Roles = [(int)Role.Predefined.Secretary],
            SpecialtiesId = []
        };
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(RoleSeeds.GetRoles());
        await AddRangeAsync(OfficeSeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthenticated_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthorized_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}employee";
        var request = new CreateEmployeeRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
