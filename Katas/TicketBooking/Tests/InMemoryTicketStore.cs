using Katas.TicketBooking.Domain;

namespace Katas.TicketBooking.Tests;

public class InMemoryTicketStore : ITicketStore
{
    readonly List<(string name, DateTimeOffset at, int available)> _performances = [];
    
    public void AddPerformance(string name, DateTimeOffset at, int available)
    {
        _performances.Add((name,at,available));
    }

    public async Task<IReadOnlyCollection<Show>> GetAllShows()
    {
        return _performances.GroupBy(p => p.name).Select(
            g => new Show(g.Key)
        ).ToList();
    }
}