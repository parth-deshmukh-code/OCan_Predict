﻿namespace DentallApp.Features.Appointments.UseCases;

public class UnavailableTimeRangeResponse
{
    public TimeSpan StartHour { get; init; }
    public TimeSpan EndHour { get; init; }
}

public interface IGetUnavailableHoursUseCase
{
    Task<List<UnavailableTimeRangeResponse>> Execute(int dentistId, DateTime appointmentDate);
}

public class GetUnavailableHoursUseCase
{
    private readonly AppDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public GetUnavailableHoursUseCase(AppDbContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<List<UnavailableTimeRangeResponse>> Execute(int dentistId, DateTime appointmentDate)
    {
        var response = await _context.Set<Appointment>()
            .Where(appointment =>
                  (appointment.DentistId == dentistId) &&
                  (appointment.Date == appointmentDate) &&
                  (appointment.IsNotCanceled() ||
                   appointment.IsCancelledByEmployee ||
                   // Checks if the canceled appointment is not available.
                   // This check allows patients to choose a time slot for an appointment canceled by another basic user.
                   _dateTimeProvider.Now > _context.AddTime(_context.ToDateTime(appointment.Date), appointment.StartHour)))
            .Select(appointment => new UnavailableTimeRangeResponse
            {
                StartHour = appointment.StartHour,
                EndHour   = appointment.EndHour
            })
            .Distinct()
            .OrderBy(appointment => appointment.StartHour)
              .ThenBy(appointment => appointment.EndHour)
            .AsNoTracking()
            .ToListAsync();

        return response;
    }
}
