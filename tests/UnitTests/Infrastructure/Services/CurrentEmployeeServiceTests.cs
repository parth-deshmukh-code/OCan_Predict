namespace UnitTests.Infrastructure.Services;

public class CurrentEmployeeServiceTests
{
    [Test]
    public void OfficeId_WhenClaimHasCorrectFormat_ShouldReturnsOfficeId()
    {
        // Arrange
        int expectedOfficeId = 1;
        var claims = new List<Claim>
        {
            new(CustomClaimsType.OfficeId, "1")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        int actual = currentEmployee.OfficeId;

        // Assert
        actual.Should().Be(expectedOfficeId);
    }

    [Test]
    public void EmployeeId_WhenClaimHasCorrectFormat_ShouldReturnsEmployeeId()
    {
        // Arrange
        int expectedEmployeeId = 1;
        var claims = new List<Claim>
        {
            new(CustomClaimsType.EmployeeId, "1")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        int actual = currentEmployee.EmployeeId;

        // Assert
        actual.Should().Be(expectedEmployeeId);
    }

    [Test]
    public void UserName_WhenClaimHasCorrectFormat_ShouldReturnsUserName()
    {
        // Arrange
        string expectedUserName = "Bob";
        var claims = new List<Claim>
        {
            new(CustomClaimsType.UserName, "Bob")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        string actual = currentEmployee.UserName;

        // Assert
        actual.Should().Be(expectedUserName);
    }

    [TestCaseSource(nameof(Actions))]
    public void Employee_WhenClaimNotFound_ShouldThrowClaimNotFoundException(Action act)
    {
        // Act & Assert
        act.Should().Throw<ClaimNotFoundException>();
    }

    static IEnumerable<Action> Actions()
    {
        var claims = new List<Claim>
        {
            new("NotFound", "1")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);
        yield return () => { int officeId = currentEmployee.OfficeId; };
        yield return () => { int employeeId = currentEmployee.EmployeeId; };
        yield return () => { string userName = currentEmployee.UserName; };
    }

    [Test]
    public void IsNotInOffice_WhenCurrentEmployeeIsNotInSpecifiedOffice_ShouldReturnsTrue()
    {
        // Arrange
        int officeId = 1;
        var claims = new List<Claim>
        {
            new(CustomClaimsType.OfficeId, "2")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsNotInOffice(officeId);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsSuperAdmin_WhenCurrentEmployeeHasRoleOfSuperadmin_ShouldReturnsTrue()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, RoleName.Superadmin)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsSuperAdmin();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsAdmin_WhenCurrentEmployeeHasRoleOfAdmin_ShouldReturnsTrue()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, RoleName.Admin)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsAdmin();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsDentist_WhenCurrentEmployeeHasRoleOfDentist_ShouldReturnsTrue()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, RoleName.Dentist)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsDentist();

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void IsOnlyDentist_WhenCurrentEmployeeIsNotSolelyDentist_ShouldReturnsFalse()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, RoleName.Admin),
            new(ClaimTypes.Role, RoleName.Dentist)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsOnlyDentist();

        // Assert
        actual.Should().BeFalse();
    }

    [Test]
    public void IsOnlyDentist_WhenCurrentEmployeeHasOnlyRoleOfDentist_ShouldReturnsTrue()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, RoleName.Dentist)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.IsOnlyDentist();

        // Assert
        actual.Should().BeTrue();
    }

    [TestCaseSource(typeof(CurrentEmployeeDoesNotHavePermissions))]
    public void HasNotPermissions_WhenCurrentEmployeeDoesNotHavePermissionsToGrantNewRoles_ShouldReturnsTrue(
        string roleType,
        List<int> rolesToBeGranted)
    {
        // Arrange
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, roleType)
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.HasNotPermissions(rolesToBeGranted);

        // Assert
        actual.Should().BeTrue();
    }

    [TestCaseSource(typeof(CurrentEmployeeDoesHavePermissions))]
    public void HasNotPermissions_WhenCurrentEmployeeDoesHavePermissionsToGrantNewRoles_ShouldReturnsFalse(
        string[] roleTypes,
        List<int> rolesToBeGranted)
    {
        // Arrange
        var claims = roleTypes
            .Select(roleType => new Claim(ClaimTypes.Role, roleType))
            .ToList();
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentEmployee = new CurrentEmployeeService(claimsPrincipal);

        // Act
        bool actual = currentEmployee.HasNotPermissions(rolesToBeGranted);

        // Assert
        actual.Should().BeFalse();
    }
}
