namespace UnitTests.Infrastructure.TestCases;

public class CurrentEmployeeDoesHavePermissions : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new[] { RoleName.Admin },
            new List<int>
            {
                (int)Role.Predefined.Secretary,
                (int)Role.Predefined.Dentist
            }
        };

        yield return new object[]
        {
            new[] { RoleName.Admin },
            new List<int> { (int)Role.Predefined.Secretary }
        };

        yield return new object[]
        {
            new[] { RoleName.Admin },
            new List<int> { (int)Role.Predefined.Dentist }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin, RoleName.Admin },
            new List<int>
            {
                (int)Role.Predefined.Secretary,
                (int)Role.Predefined.Dentist,
                (int)Role.Predefined.Admin
            }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin, RoleName.Admin },
            new List<int> { (int)Role.Predefined.Secretary }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin, RoleName.Admin },
            new List<int> { (int)Role.Predefined.Dentist }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin, RoleName.Admin },
            new List<int> { (int)Role.Predefined.Admin }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin },
            new List<int>
            {
                (int)Role.Predefined.Secretary,
                (int)Role.Predefined.Dentist,
                (int)Role.Predefined.Admin
            }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin },
            new List<int> { (int)Role.Predefined.Secretary }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin },
            new List<int> { (int)Role.Predefined.Dentist }
        };

        yield return new object[]
        {
            new[] { RoleName.Superadmin },
            new List<int> { (int)Role.Predefined.Admin }
        };
    }
}
