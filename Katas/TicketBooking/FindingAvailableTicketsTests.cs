using Katas.TicketBooking.UseCases;

namespace Katas.TicketBooking;

public class FindingAvailableTicketsTests
{
    [Test]
    public async Task NoShows_EmptyResponse()
    {
        var useCase = new FindTickets();
        var result = await useCase.Execute();
        result.Shows.ShouldBeEmpty();
    }
}