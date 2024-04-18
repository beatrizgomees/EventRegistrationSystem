using ativa_recife.General;

namespace ativa_recife.events;

public interface EventRepository : GeneralRepository<Event, AddEventRequest>
{
    Task<Event> newEvent(Event newEvent);
    
}