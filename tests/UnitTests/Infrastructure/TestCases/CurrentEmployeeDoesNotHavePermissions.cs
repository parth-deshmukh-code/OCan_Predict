namespace UnitTests.Infrastructure.TestCases;

public class CurrentEmployeeDoesNotHavePermissions : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            RoleName.Admin,
            new List<int>
            {
                (int)Role.Predefined.Unverified,
                (int)Role.Predefined.BasicUser,
                (int)Role.Predefined.Admin,
                (int)Role.Predefined.Superadmin
            }
        };

        yield return new object[]
        {
            RoleName.Admin,
            new List<int> { (int)Role.Predefined.Unverified }
        };

        yield return new object[]
        {
            RoleName.Admin,
            new List<int> { (int)Role.Predefined.BasicUser }
        };

        yield return new object[]
        {
            RoleName.Admin,
            new List<int> { (int)Role.Predefined.Admin }
        };

        yield return new object[]
        {
            RoleName.Admin,
            new List<int> { (int)Role.Predefined.Superadmin }
        };

        yield return new object[]
        {
            RoleName.Superadmin,
            new List<int> { (int)Role.Predefined.Unverified }
        };

        yield return new object[]
        {
            RoleName.Superadmin,
            new List<int> { (int)Role.Predefined.BasicUser }
        };

        yield return new object[]
        {
            RoleName.Superadmin,
            new List<int> { (int)Role.Predefined.Superadmin }
        };

        yield return new object[]
        {
            RoleName.Superadmin,
            new List<int>
            {
                (int)Role.Predefined.Unverified,
                (int)Role.Predefined.BasicUser,
                (int)Role.Predefined.Superadmin
            }
        };

        yield return new object[]
        {
            RoleName.Secretary,
            new List<int> { (int)Role.Predefined.Secretary }
        };

        yield return new object[]
        {
            RoleName.Secretary,
            new List<int> { (int)Role.Predefined.Dentist }
        };

        yield return new object[]
        {
            RoleName.Secretary,
            new List<int> { (int)Role.Predefined.Admin }
        };

        yield return new object[]
        {
            RoleName.Secretary,
            new List<int> { (int)Role.Predefined.Superadmin }
        };

        yield return new object[]
        {
            RoleName.Dentist,
            new List<int> { (int)Role.Predefined.Secretary }
        };

        yield return new object[]
        {
            RoleName.Dentist,
            new List<int> { (int)Role.Predefined.Dentist }
        };

        yield return new object[]
        {
            RoleName.Dentist,
            new List<int> { (int)Role.Predefined.Admin }
        };

        yield return new object[]
        {
            RoleName.Dentist,
            new List<int> { (int)Role.Predefined.Superadmin }
        };
    }
}
