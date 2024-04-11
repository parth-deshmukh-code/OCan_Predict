namespace IntegrationTests.Common.Seeds;

public class GeneralTreatmentSeeds
{
    public static List<GeneralTreatment> Get()
        =>
        [
             new()
             {
                 Id = 1,
                 Name = "Ortodoncia/brackets",
                 Description = "Test",
                 ImageUrl = "ortodoncia.png",
                 Duration = 40
             },
             new()
             {
                 Id = 2,
                 Name = "Calces/resinas",
                 Description = "Test",
                 ImageUrl = "calce.png",
                 Duration = 40
             },
             new()
             {
                 Id = 3,
                 Name = "Tratamiento de conductos/endodoncia",
                 Description = "Test",
                 ImageUrl = "endodoncia.png",
                 Duration = 180
             },
        ];
}
