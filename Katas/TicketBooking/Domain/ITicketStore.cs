namespace Katas.TicketBooking.Domain;

public interface ITicketStore
{
    Task<IReadOnlyCollection<Show>> GetAllShows();
}