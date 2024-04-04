namespace IntegrationTests.Common.Seeds;

public static class BaseSeeds
{
    public static List<AppointmentStatus> GetAppointmentStatuses()
        =>
        [
            new() { Id = 1, Name = StatusType.Scheduled },
            new() { Id = 2, Name = StatusType.NotAssisted },
            new() { Id = 3, Name = StatusType.Assisted },
            new() { Id = 4, Name = StatusType.Canceled }
        ];

    public static List<Gender> GetGenders()
        =>
        [
            new() { Id = 1, Name = GenderName.Male },
            new() { Id = 2, Name = GenderName.Female }
        ];

    public static List<Kinship> GetKinships()
        =>
        [
            new() { Id = 1, Name = KinshipName.Spouse },
            new() { Id = 2, Name = KinshipName.Child },
            new() { Id = 3, Name = KinshipName.Other }
        ];
}
