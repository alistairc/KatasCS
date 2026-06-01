namespace Katas.TicketBooking.UseCases;

public record FindTicketsResult
{
    public IReadOnlyCollection<object> Shows { get; } = [];
}