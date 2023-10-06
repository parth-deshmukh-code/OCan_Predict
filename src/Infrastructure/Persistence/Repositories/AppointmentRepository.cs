﻿using LinqToDB;

namespace DentallApp.Infrastructure.Persistence.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly DbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public AppointmentRepository(DbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    private async Task<int> CancelAppointmentsAsync(int officeId, int dentistId, IEnumerable<int> appointmentsId)
    {
        if (appointmentsId.Any())
        {
            int updatedRows = await _context.Set<Appointment>()
                .OptionalWhere(officeId, appointment => appointment.OfficeId == officeId)
                .OptionalWhere(dentistId, appointment => appointment.DentistId == dentistId)
                .Where(appointment =>
                       appointment.AppointmentStatusId == AppointmentStatusId.Scheduled &&
                       appointmentsId.Contains(appointment.Id))
                .Set(appointment => appointment.AppointmentStatusId, AppointmentStatusId.Canceled)
                .Set(appointment => appointment.IsCancelledByEmployee, true)
                .Set(appointment => appointment.UpdatedAt, _dateTimeService.Now)
                .UpdateAsync();

            return updatedRows;
        }

        return default;
    }

    public Task<int> CancelAppointmentsByOfficeIdAsync(int officeId, IEnumerable<int> appointmentsId)
    {
        return CancelAppointmentsAsync(officeId, dentistId: default, appointmentsId);
    }

    public Task<int> CancelAppointmentsByDentistIdAsync(int dentistId, IEnumerable<int> appointmentsId)
    {
        return CancelAppointmentsAsync(officeId: default, dentistId, appointmentsId);
    }
}
