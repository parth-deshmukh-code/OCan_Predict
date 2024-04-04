namespace IntegrationTests.Common.Seeds;

public static class PersonSeeds
{
    public static List<Person> GetPersons()
        =>
        [
            new()
            {
                Id = 1,
                Document = "0923611701",
                Names = "David Sebastian",
                LastNames = "Roman Amariles",
                CellPhone = "0953581032",
                Email = "dave123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            },
            new()
            {
                Id = 2,
                Document = "0923611733",
                Names = "Roberto Emilio",
                LastNames = "Placencio Pinto",
                CellPhone = "0953581040",
                Email = "roberto123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            },
            new()
            {
                Id = 3,
                Document = "0923611744",
                Names = "Guillermo Emilio",
                LastNames = "Rivera Pinto",
                CellPhone = "0953581060",
                Email = "guillermo123@hotmail.com",
                DateBirth = new DateTime(1997, 01, 01),
                GenderId = 1
            },
            new()
            {
                Id = 4,
                Document = "0923611899",
                Names = "Derian Emilio",
                LastNames = "Arias Pinto",
                CellPhone = "0953581178",
                Email = "derian123@hotmail.com",
                DateBirth = new DateTime(1996, 02, 01),
                GenderId = 1
            }
        ];
}
