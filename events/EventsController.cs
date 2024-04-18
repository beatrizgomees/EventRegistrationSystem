using ativa_recife.data;

namespace ativa_recife.events;

public static class EventsController
{

    public static void addEventController ( this WebApplication app)
    {
        var group = app.MapGroup("events");
        
        group.MapPost("", async (AddEventRequest request, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
            EventService eventService = new EventService(eventRepositoryImp);
            var newEvent = new Event(request.Title, request.Description, request.Date, request.Hour, request.Local);
            eventService.CreateEvent(newEvent);
    
          
        });

        group.MapDelete("", async (string eventTitle, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
    
            EventService eventService = new EventService(eventRepositoryImp);
    
            Event eventToDelete = new Event { Title = eventTitle };

            await eventService.DeleteEvent(eventToDelete);
        });
        
        group.MapPut("", async ( Event updatedEvent, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
    
            EventService eventService = new EventService(eventRepositoryImp);

            await eventService.UpdateEvent(updatedEvent);
        });
        
        group.MapGet("/{eventTitle}", async (string eventTitle, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
    
            EventService eventService = new EventService(eventRepositoryImp);
    
            Event getEvent = new Event { Title = eventTitle };

            var existingEvent = await eventService.GetEventByTitle(getEvent);

            return existingEvent;
        });
        
        

    }
    
}