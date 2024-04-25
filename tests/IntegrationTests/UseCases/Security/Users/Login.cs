namespace IntegrationTests.UseCases.Security.Users;

public class UserLogin : TestBase
{
    [TestCase("basic_user@hotmail.com")]
    [TestCase("BASIC_USER@HOTMAIL.COM")]
    public async Task Post_WhenBasicUserLogsIn_ShouldReturnsOk(string userName)
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = userName,
            Password = "123456"
        };
        var expectedBasicUser = new UserLoginResponse
        {
            UserId = 2,
            PersonId = 2,
            GenderId = 1,
            UserName = "basic_user@hotmail.com",
            Roles = [RoleName.BasicUser],
            GenderName = GenderName.Male,
            Document = "0923611733",
            Names = "Roberto Emilio",
            LastNames = "Placencio Pinto",
            FullName = "Roberto Emilio Placencio Pinto",
            CellPhone = "0953581040",
            DateBirth = new DateTime(1997, 01, 01)
        };
        await CreateSeedData();
        await AddRangeAsync(EmployeeSeeds.Get());
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, "25-04-2024");

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<UserLoginResponse>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Data
              .Should()
              .BeEquivalentTo(expectedBasicUser, o =>
              {
                  return o.Excluding(user => user.AccessToken)
                          .Excluding(user => user.RefreshToken);
              });

        result.Data
              .AccessToken
              .Should()
              .NotBeNullOrWhiteSpace();

        result.Data
              .RefreshToken
              .Should()
              .NotBeNullOrWhiteSpace();
    }

    [TestCase("dentist@hotmail.com")]
    [TestCase("DENTIST@HOTMAIL.COM")]
    public async Task Post_WhenEmployeeLogsIn_ShouldReturnsOk(string userName)
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = userName,
            Password = "123456"
        };
        var expectedEmployee = new EmployeeLoginResponse
        {
            EmployeeId = 2,
            UserId = 4,
            PersonId = 4,
            OfficeId = 1,
            GenderId = 1,
            UserName = "dentist@hotmail.com",
            Roles = [RoleName.Dentist],
            GenderName = GenderName.Male,
            Document = "0923611899",
            Names = "Derian Emilio",
            LastNames = "Arias Pinto",
            FullName = "Derian Emilio Arias Pinto",
            CellPhone = "0953581178",
            DateBirth = new DateTime(1996, 02, 01),
            OfficeName = "Mapasingue",
            PregradeUniversity = "UG",
            PostgradeUniversity = "UG"
        };
        await CreateSeedData();
        await AddRangeAsync(EmployeeSeeds.Get());
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, "25-04-2024");

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<EmployeeLoginResponse>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Data
              .Should()
              .BeEquivalentTo(expectedEmployee, o =>
              {
                  return o.Excluding(user => user.AccessToken)
                          .Excluding(user => user.RefreshToken);
              });

        result.Data
              .AccessToken
              .Should()
              .NotBeNullOrWhiteSpace();

        result.Data
              .RefreshToken
              .Should()
              .NotBeNullOrWhiteSpace();
    }

    [Test]
    public async Task Post_WhenFieldsAreEmpty_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = string.Empty,
            Password = string.Empty
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [TestCase("dentist@hotmail.com",    "dentist123")]
    [TestCase("basic_user@hotmail.com", "basicuser123")]
    [TestCase("tuya@hotmail.com",       "tuyaa123")]
    [TestCase("roberto123@hotmail.es",  "123456")]
    public async Task Post_WhenEmailOrPasswordIsIncorrect_ShouldReturnsUnauthorized(
        string userName,
        string password)
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = userName,
            Password = password
        };
        var expectedMessage = Messages.EmailOrPasswordIncorrect;
        await CreateSeedData();
        await AddRangeAsync(EmployeeSeeds.Get());

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        result.Message.Should().Be(expectedMessage);
    }

    [Test]
    public async Task Post_WhenEmailIsNotConfirmed_ShouldReturnsForbidden()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = "unverified_user@hotmail.com",
            Password = "123456"
        };
        var expectedMessage = Messages.EmailNotConfirmed;
        await CreateSeedData();
        await AddRangeAsync(EmployeeSeeds.Get());

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
    public async Task Post_WhenEmployeeAccountIsInactive_ShouldReturnsForbidden()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}user/login";
        var request = new UserLoginRequest
        {
            UserName = "secretary@hotmail.com",
            Password = "123456"
        };
        var expectedMessage = Messages.InactiveUserAccount;
        await CreateSeedData();
        await AddRangeAsync(EmployeeSeeds.Get(isDeleted: true));
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, "25-04-2024");

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        result.Message.Should().Be(expectedMessage);
    }

    private async Task CreateSeedData()
    {
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(RoleSeeds.GetRoles());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
        await AddRangeAsync(RoleSeeds.GetUserRoles());
        await AddRangeAsync(OfficeSeeds.Get());
    }
}
