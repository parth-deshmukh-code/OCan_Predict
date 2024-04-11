namespace IntegrationTests.Common.Seeds;

public class UserSeeds
{
    /// <summary>
    /// Password Text: 123456
    /// </summary>
    private const string Password = "$2a$10$60QnEiafBCLfVBMfQkExVeolyBxVHWcSQKTvkxVJj9FUozRpRP/GW";
    public static List<User> Get()
        =>
        [
            new()
            {
                Id = 1,
                PersonId = 1,
                UserName = "unverified_user@hotmail.com",
                Password = Password
            },
            new()
            {
                Id = 2,
                PersonId = 2,
                UserName = "basic_user@hotmail.com",
                Password = Password
            },
            new()
            {
                Id = 3,
                PersonId = 3,
                UserName = "secretary@hotmail.com",
                Password = Password
            },
            new()
            {
                Id = 4,
                PersonId = 4,
                UserName = "dentist@hotmail.com",
                Password = Password
            },
            new()
            {
                Id = 5,
                PersonId = 5,
                UserName = "admin@hotmail.com",
                Password = Password
            },
            new()
            {
                Id = 6,
                PersonId = 6,
                UserName = "superadmin@hotmail.com",
                Password = Password
            }
        ];
}
