namespace IntegrationTests.Common.Seeds;

public class WeekDaySeeds
{
    public static List<WeekDay> Get()
        =>
        [
            new()
            {
                Id = 1,
                Name = WeekDayName.Monday
            },
            new()
            {
                Id = 2,
                Name = WeekDayName.Tuesday
            },
            new()
            {
                Id = 3,
                Name = WeekDayName.Wednesday
            },
            new()
            {
                Id = 4,
                Name = WeekDayName.Thursday
            },
            new()
            {
                Id = 5,
                Name = WeekDayName.Friday
            },
            new()
            {
                Id = 6,
                Name = WeekDayName.Saturday
            },
            new()
            {
                Id = 7,
                Name = WeekDayName.Sunday
            }
        ];
}
