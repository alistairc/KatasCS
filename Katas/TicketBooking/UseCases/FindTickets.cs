using Katas.TicketBooking.Domain;

namespace Katas.TicketBooking.UseCases;

public class FindTickets(ITicketStore dataStore)
{
    public async Task<FindTicketsResult> Execute()
    {
        var shows = await dataStore.GetAllShows();
        return new FindTicketsResult(shows);
    }
}