namespace Katas.TicketBooking.UseCases;

public record FindTicketsResult(IReadOnlyCollection<Show> Shows);