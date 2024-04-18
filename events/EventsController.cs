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

        group.MapDelete("", async (AddEventRequest request, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
            EventService eventService = new EventService(eventRepositoryImp);
            var newEvent = new Event(request.Title, request.Description, request.Date, request.Hour, request.Local);
            eventService.DeleteEvent(newEvent);
        });

        group.MapPut("", async (AddEventRequest request, AppDBContext appDbContext) =>
        {
            EventRepositoryImp eventRepositoryImp = new EventRepositoryImp(appDbContext);
            EventService eventService = new EventService(eventRepositoryImp);
            var newEvent = new Event(request.Title, request.Description, request.Date, request.Hour, request.Local);
            eventService.UpdateEvent(newEvent);
        });
    }
    
}