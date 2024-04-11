namespace IntegrationTests.Common.Seeds;

public class OfficeSeeds
{
    public static List<Office> Get()
        =>
        [
            new()
            {
                Id = 1,
                Name = "Mapasingue",
                Address = "None",
                ContactNumber = "0980852228"
            },
            new()
            {
                Id = 2,
                Name = "El Triunfo",
                Address = "None",
                ContactNumber = "0980852228"
            },
            new()
            {
                Id = 3,
                Name = "Naranjito",
                Address = "None",
                ContactNumber = "0980852228"
            }
        ];
}
