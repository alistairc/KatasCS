namespace Katas.TicketBooking.UseCases;

public interface ITicketStore
{
    Task<IReadOnlyCollection<Show>> GetAllShows();
}