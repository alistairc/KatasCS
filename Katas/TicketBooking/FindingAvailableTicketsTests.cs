using Katas.TicketBooking.UseCases;

namespace Katas.TicketBooking;

public class FindingAvailableTicketsTests
{
    [Test]
    public async Task NoShows_EmptyResponse()
    {
        var useCase = new FindTickets(new InMemoryTicketStore());
        var result = await useCase.Execute();
        result.Shows.ShouldBeEmpty();
    }

    [Test]
    public async Task SomeShows_VaryingTicketAmounts()
    {
        var dataStore = new InMemoryTicketStore();
        dataStore.AddPerformance(
            "Macbeth",
            new DateTimeOffset(2026, 6, 1, 20, 00, 00, new TimeSpan(1, 0, 0)),
            available: 53
        );
        dataStore.AddPerformance(
            "Macbeth",
            new DateTimeOffset(2026, 6, 2, 20, 00, 00, new TimeSpan(1, 0, 0)),
            available: 0
        );
        dataStore.AddPerformance(
            "Romeo and Juliet",
            new DateTimeOffset(2026, 6, 2, 20, 00, 00, new TimeSpan(1, 0, 0)),
            available: 10
        );
        var useCase = new FindTickets(dataStore);
        var result = await useCase.Execute();
        result.Shows.ShouldNotBeEmpty();
        result.Shows.Select(show => show.Name).ToArray()
            .ShouldBeEquivalentTo(new[] {"Macbeth", "Romeo and Juliet"});
        
        //TODO: no availability count yet
    }
}

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