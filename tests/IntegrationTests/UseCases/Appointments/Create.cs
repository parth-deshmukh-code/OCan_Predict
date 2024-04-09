namespace IntegrationTests.UseCases.Appointments;

public class CreateAppointment : TestBase
{
    [Test]
    public async Task Post_WhenAppointmentIsCreated_ShouldReturnsCreated()
    {
        // Arrange
        int expectedId = 1;
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}appointment";
        var request = new CreateAppointmentRequest
        {
            UserId = 2,
            PersonId = 2,
            DentistId = 2,
            GeneralTreatmentId = 1,
            OfficeId = 1,
            AppointmentDate = new DateTime(2024, 04, 09),
            StartHour = new TimeSpan(10, 0, 0),
            EndHour = new TimeSpan(11, 0, 0)
        };
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, "2024-04-09 07:00");
        await CreateSeedData();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result<CreatedId>>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        result.Data.Id.Should().Be(expectedId);
    }

    [TestCaseSource(nameof(DateAndTimeAppointmentIsNotAvailableTestCases))]
    public async Task Post_WhenDateAndTimeAppointmentIsNotAvailable_ShouldReturnsUnprocessableEntity(
        Appointment appointment)
    {
        // Arrange
        var expectedMessage = Messages.DateAndTimeAppointmentIsNotAvailable;
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}appointment";
        var request = new CreateAppointmentRequest
        {
            UserId = 2,
            PersonId = 2,
            DentistId = 2,
            GeneralTreatmentId = 1,
            OfficeId = 1,
            AppointmentDate = appointment.Date,
            StartHour = appointment.StartHour,
            EndHour = appointment.EndHour
        };
        Environment.SetEnvironmentVariable(TestSettings.CurrentDateTime, "2024-04-09 07:00");
        await CreateSeedData();
        await AddAsync(appointment);

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await httpResponse
            .Content
            .ReadFromJsonAsync<Result>();

        // Asserts
        httpResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        result.Message.Should().Be(expectedMessage);
    }
    
    static IEnumerable<Appointment> DateAndTimeAppointmentIsNotAvailableTestCases()
    {
        yield return new Appointment
        {
            UserId = 2,
            PersonId = 2,
            DentistId = 2,
            GeneralTreatmentId = 1,
            OfficeId = 1,
            AppointmentStatusId = (int)AppointmentStatus.Predefined.Scheduled,
            Date = new DateTime(2024, 04, 09),
            StartHour = new TimeSpan(10, 0, 0),
            EndHour = new TimeSpan(11, 0, 0),
            IsCancelledByEmployee = false
        };

        yield return new Appointment
        {
            UserId = 2,
            PersonId = 2,
            DentistId = 2,
            GeneralTreatmentId = 1,
            OfficeId = 1,
            AppointmentStatusId = (int)AppointmentStatus.Predefined.Canceled,
            Date = new DateTime(2024, 04, 08),
            StartHour = new TimeSpan(10, 0, 0),
            EndHour = new TimeSpan(11, 0, 0),
            IsCancelledByEmployee = false
        };

        yield return new Appointment
        {
            UserId = 2,
            PersonId = 2,
            DentistId = 2,
            GeneralTreatmentId = 1,
            OfficeId = 1,
            AppointmentStatusId = (int)AppointmentStatus.Predefined.Canceled,
            Date = new DateTime(2024, 04, 09),
            StartHour = new TimeSpan(5, 0, 0),
            EndHour = new TimeSpan(6, 0, 0),
            IsCancelledByEmployee = true
        };
    }

    [Test]
    public async Task Post_WhenRequestIsInvalid_ShouldReturnsBadRequest()
    {
        // Arrange
        var client = CreateClientAsSecretary();
        var requestUri = $"{TestSettings.BaseUri}appointment";
        var request = new CreateAppointmentRequest
        {
            UserId = 0,
            PersonId = 0,
            DentistId = 0,
            GeneralTreatmentId = 0,
            OfficeId = 0,
            StartHour = new TimeSpan(11, 0, 0),
            EndHour = new TimeSpan(10, 0, 0)
        };

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthenticated_ShouldReturnsUnauthorized()
    {
        // Arrange
        var client = ApplicationFactory.CreateClient();
        var requestUri = $"{TestSettings.BaseUri}appointment";
        var request = new CreateAppointmentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task Post_WhenUserIsNotAuthorized_ShouldReturnsForbidden()
    {
        // Arrange
        var client = CreateClientAsBasicUser();
        var requestUri = $"{TestSettings.BaseUri}appointment";
        var request = new CreateAppointmentRequest();

        // Act
        var httpResponse = await client.PostAsJsonAsync(requestUri, request);

        // Assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

    private async Task CreateSeedData()
    {
        await AddRangeAsync(BaseSeeds.GetGenders());
        await AddRangeAsync(BaseSeeds.GetAppointmentStatuses());
        await AddRangeAsync(PersonSeeds.Get());
        await AddRangeAsync(UserSeeds.Get());
        await AddRangeAsync(OfficeSeeds.Get());
        await AddRangeAsync(EmployeeSeeds.Get());
        await AddRangeAsync(GeneralTreatmentSeeds.Get());
    }
}
