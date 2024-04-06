namespace IntegrationTests.Common.Seeds;

public class PersonSeeds
{
    public static List<Person> Get()
        =>
        [
            new()
            {
                Id = 1,
                Document = "0923611701",
                Names = "David Sebastian",
                LastNames = "Roman Amariles",
                CellPhone = "0953581032",
                Email = "unverified_user@hotmail.com",
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
                Email = "basic_user@hotmail.com",
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
                Email = "secretary@hotmail.com",
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
                Email = "dentist@hotmail.com",
                DateBirth = new DateTime(1996, 02, 01),
                GenderId = 1
            },
            new()
            {
                Id = 5,
                Document = "0923611901",
                Names = "Joel Emilio",
                LastNames = "Delgado Figueroa",
                CellPhone = "0953581289",
                Email = "admin@hotmail.com",
                DateBirth = new DateTime(1996, 05, 02),
                GenderId = 1
            },
            new()
            {
                Id = 6,
                Document = "0923629901",
                Names = "Johan Elias",
                LastNames = "Sanchez Pinto",
                CellPhone = "0953590089",
                Email = "superadmin@hotmail.com",
                DateBirth = new DateTime(1998, 08, 27),
                GenderId = 1
            }
        ];
}
