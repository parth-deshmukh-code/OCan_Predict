namespace IntegrationTests.Common;

public partial class TestBase
{
    protected HttpClient CreateClientAsBasicUser()
        => CreateClientAsUser(new UserClaims
        {
            UserId   = 1,
            PersonId = 1,
            UserName = "basic_user@hotmail.com",
            FullName = "Basic User",
            Roles    = [RoleName.BasicUser]
        });

    protected HttpClient CreateClientAsSuperadmin()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 2,
            PersonId   = 2,
            UserName   = "superadmin@hotmail.com",
            FullName   = "Superadmin",
            Roles      = [RoleName.Superadmin],
            EmployeeId = 1,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsAdmin()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 3,
            PersonId   = 3,
            UserName   = "admin@hotmail.com",
            FullName   = "Admin",
            Roles      = [RoleName.Admin],
            EmployeeId = 2,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsDentist()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 4,
            PersonId   = 4,
            UserName   = "dentist@hotmail.com",
            FullName   = "Dentist",
            Roles      = [RoleName.Dentist],
            EmployeeId = 3,
            OfficeId   = 1
        });

    protected HttpClient CreateClientAsSecretary()
        => CreateClientAsEmployee(new EmployeeClaims
        {
            UserId     = 5,
            PersonId   = 5,
            UserName   = "secretary@hotmail.com",
            FullName   = "Secretary",
            Roles      = [RoleName.Secretary],
            EmployeeId = 4,
            OfficeId   = 1
        });


    protected HttpClient CreateClientAsUser(UserClaims user)
    {
        using var httpClient = ApplicationFactory.CreateClient();
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
        using var httpClient = ApplicationFactory.CreateClient();
        using var serviceScope = ApplicationFactory.Services.CreateScope();
        var tokenService = serviceScope.ServiceProvider.GetService<ITokenService>();
        var accessToken = tokenService.CreateAccessToken(employee);
        httpClient
            .DefaultRequestHeaders
            .Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return httpClient;
    }
}
