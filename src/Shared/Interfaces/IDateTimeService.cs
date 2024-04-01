namespace DentallApp.Shared.Interfaces;

/// <summary>
/// This interface allows tests to run successfully regardless of the system clock.
/// </summary>
public interface IDateTimeService
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
