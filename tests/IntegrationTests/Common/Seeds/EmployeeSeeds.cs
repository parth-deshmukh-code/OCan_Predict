namespace IntegrationTests.Common.Seeds;

public class EmployeeSeeds
{
    /// <summary>
    /// Gets a list of employees.
    /// </summary>
    /// <param name="isDeleted">
    /// Indicates whether all employees should be temporarily deleted.
    /// </param>
    public static List<Employee> Get(bool isDeleted = false)
        =>
        [
            new()
            {
                Id = 1,
                UserId = 3,
                PersonId = 3,
                OfficeId = 1,
                IsDeleted = isDeleted
            },
            new()
            {
                Id = 2,
                UserId = 4,
                PersonId = 4,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG",
                IsDeleted = isDeleted
            },
            new()
            {
                Id = 3,
                UserId = 5,
                PersonId = 5,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG",
                IsDeleted = isDeleted
            },
            new()
            {
                Id = 4,
                UserId = 6,
                PersonId = 6,
                OfficeId = 1,
                PregradeUniversity = "UG",
                PostgradeUniversity = "UG",
                IsDeleted = isDeleted
            }
        ];
}
