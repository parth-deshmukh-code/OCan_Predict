namespace IntegrationTests.Common.Seeds;

public class EmployeeSeeds
{
    public static List<Employee> Get()
        =>
        [
            new()
            {
                Id = 1,
                UserId = 3,
                PersonId = 3,
                OfficeId = 1
            },
            new()
            {
                Id = 2,
                UserId = 4,
                PersonId = 4,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG"
            },
            new()
            {
                Id = 3,
                UserId = 5,
                PersonId = 5,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG"
            },
            new()
            {
                Id = 4,
                UserId = 6,
                PersonId = 6,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG"
            }
        ];
}
