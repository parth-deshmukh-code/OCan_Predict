namespace DentallApp.Shared.Interfaces;

/// <summary>
/// This interface is used so that unit or integration tests do not depend on the system clock.
/// </summary>
public interface IDateTimeService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
