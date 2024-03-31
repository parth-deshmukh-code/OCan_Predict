namespace DentallApp.Shared.Models.Claims;

public class UserClaims
{
    public int UserId { get; init; }
    public int PersonId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string FullName { get; init; } = string.Empty;
    public IEnumerable<string> Roles { get; init; } = [];
}
