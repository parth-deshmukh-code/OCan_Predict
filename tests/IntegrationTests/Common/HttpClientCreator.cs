namespace IntegrationTests.Common;

public partial class TestBase
{
    protected HttpClient CreateClientAsUnverifiedUser()
        => CreateClientAsUser(new UserClaims
        {
            UserId   = 1,
            PersonId = 1,
            UserName = "unverified_user@hotmail.com",
            FullName = "David Sebastian Roman Amariles",
            Roles    = [RoleName.Unverified]
        });


    protected HttpClient CreateClientAsBasicUser()
        => CreateClientAsUser(new UserClaims
        {
            UserId   = 2,
            PersonId = 2,
            UserName = "basic_user@hotmail.com",
            FullName = "Roberto Emilio Placencio Pinto",
            Roles    = [RoleName.BasicUser]
        });

    protected HttpClient CreateClientAsSecretary()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 3,
            PersonId   = 3,
            UserName   = "secretary@hotmail.com",
            FullName   = "Guillermo Emilio Rivera Pinto",
            Roles      = [RoleName.Secretary],
            EmployeeId = 1,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsDentist()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 4,
            PersonId   = 4,
            UserName   = "dentist@hotmail.com",
            FullName   = "Derian Emilio Arias Pinto",
            Roles      = [RoleName.Dentist],
            EmployeeId = 2,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsAdmin()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 5,
            PersonId   = 5,
            UserName   = "admin@hotmail.com",
            FullName   = "Joel Emilio Delgado Figueroa",
            Roles      = [RoleName.Admin],
            EmployeeId = 3,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsSuperadmin()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 6,
            PersonId   = 6,
            UserName   = "superadmin@hotmail.com",
            FullName   = "Johan Elias Sanchez Pinto",
            Roles      = [RoleName.Superadmin],
            EmployeeId = 4,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsUser(UserClaims user)
    {
        var httpClient = ApplicationFactory.CreateClient();
        using var serviceScope = ApplicationFactory.Services.CreateScope();
        var tokenService = serviceScope.ServiceProvider.GetService<ITokenService>();
        var accessToken = tokenService.CreateAccessToken(user);
        httpClient
            .DefaultRequestHeaders
            .Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return httpClient;
    }

    protected HttpClient CreateClientAsEmployee(EmployeeClaims employee)
    {
        var httpClient = ApplicationFactory.CreateClient();
        using var serviceScope = ApplicationFactory.Services.CreateScope();
        var tokenService = serviceScope.ServiceProvider.GetService<ITokenService>();
        var accessToken = tokenService.CreateAccessToken(employee);
        httpClient
            .DefaultRequestHeaders
            .Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return httpClient;
    }
}
