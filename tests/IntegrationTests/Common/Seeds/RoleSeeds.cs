namespace IntegrationTests.Common.Seeds;

public class RoleSeeds
{
    public static List<Role> GetRoles()
        =>
        [
            new() { Id = 1, Name = RoleName.Unverified },
            new() { Id = 2, Name = RoleName.BasicUser },
            new() { Id = 3, Name = RoleName.Secretary },
            new() { Id = 4, Name = RoleName.Dentist },
            new() { Id = 5, Name = RoleName.Admin },
            new() { Id = 6, Name = RoleName.Superadmin }
        ];

    public static List<UserRole> GetUserRoles()
        =>
        [
            new() 
            { 
                Id = 1, 
                UserId = 1, 
                RoleId = (int)Role.Predefined.Unverified 
            },
            new()
            {
                Id = 2,
                UserId = 2,
                RoleId = (int)Role.Predefined.BasicUser
            },
            new()
            {
                Id = 3,
                UserId = 3,
                RoleId = (int)Role.Predefined.Secretary
            },
            new()
            {
                Id = 4,
                UserId = 4,
                RoleId = (int)Role.Predefined.Dentist
            },
            new()
            {
                Id = 5,
                UserId = 5,
                RoleId = (int)Role.Predefined.Admin
            },
            new()
            {
                Id = 6,
                UserId = 6,
                RoleId = (int)Role.Predefined.Superadmin
            }
        ];
}
