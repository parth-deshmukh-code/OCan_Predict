namespace UnitTests.Infrastructure.Services;

public class CurrentUserServiceTests
{
    [Test]
    public void PersonId_WhenClaimHasCorrectFormat_ShouldReturnsPersonId()
    {
        // Arrange
        int expectedPersonId = 1;
        var claims = new List<Claim> 
        { 
            new(CustomClaimsType.PersonId, "1") 
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentUser = new CurrentUserService(claimsPrincipal);

        // Act
        int actual = currentUser.PersonId;

        // Assert
        actual.Should().Be(expectedPersonId);
    }

    [Test]
    public void UserId_WhenClaimHasCorrectFormat_ShouldReturnsUserId()
    {
        // Arrange
        int expectedUserId = 1;
        var claims = new List<Claim>
        {
            new(CustomClaimsType.UserId, "1")
        };
        var claimsIdentity = new ClaimsIdentity(claims);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        var currentUser = new CurrentUserService(claimsPrincipal);

        // Act
        int actual = currentUser.UserId;

        // Assert
        actual.Should().Be(expectedUserId);
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
        var currentUser = new CurrentUserService(claimsPrincipal);

        // Act
        string actual = currentUser.UserName;

        // Assert
        actual.Should().Be(expectedUserName);
    }

    [TestCaseSource(nameof(Actions))]
    public void User_WhenClaimNotFound_ShouldThrowClaimNotFoundException(Action act)
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
        var currentUser = new CurrentUserService(claimsPrincipal);
        yield return () => { int personId = currentUser.PersonId; };
        yield return () => { int userId = currentUser.UserId; };
        yield return () => { string userName = currentUser.UserName; };
    }
}
