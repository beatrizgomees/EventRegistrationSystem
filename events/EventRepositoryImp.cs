using System.Linq.Expressions;
using ativa_recife.data;
using ativa_recife.Exception;
using ativa_recife.General;
using Microsoft.EntityFrameworkCore;

namespace ativa_recife.events;

public class EventRepositoryImp : GeneralRepository<Event>
{
     public readonly AppDBContext _appDbContext;

    public EventRepositoryImp(AppDBContext dbContext)
    {
        _appDbContext = dbContext;
    }
    public async Task<Event> Create(Event newEvent)
    {

        AddEventRequest request = new AddEventRequest(newEvent.Title, newEvent.Description, newEvent.Date, newEvent.Hour, newEvent.Local);
        if(!string.IsNullOrEmpty(newEvent.Title))
        {
            newEvent = new Event(request.Title, 
                request.Description, 
                request.Date, 
                request.Hour, 
                request.Local);
            
            await _appDbContext.Event.AddAsync(newEvent);
            await _appDbContext.SaveChangesAsync();
        }

        return newEvent;
    }



    public async Task<Event> Update(Event eventObj)
    {
        var existingEvent = await _appDbContext.Event.FindAsync(eventObj.Id);

        // Verifica se o evento existe
        if (existingEvent != null)
        {
            // Atualiza as propriedades do evento existente com as do evento fornecido
            existingEvent.Title = eventObj.Title;
            existingEvent.Description = eventObj.Description;
            existingEvent.Date = eventObj.Date;
            existingEvent.Hour = eventObj.Hour;
            existingEvent.Local = eventObj.Local;

            // Salva as alterações no banco de dados
            await _appDbContext.SaveChangesAsync();
        }

        return existingEvent;
    }

    public async Task<Event> Delete(Event eventObj)
    {
        var findEvent = await _appDbContext.Event.FindAsync(eventObj.Id);
        if (findEvent != null)
        {
            _appDbContext.Event.Remove(findEvent);

            await _appDbContext.SaveChangesAsync();
        }
        return findEvent;
    }

    public async Task<Event> GetEventByTitle(Event getEvent)
    {
        var existingEvent = await _appDbContext.Event.FirstOrDefaultAsync(e => e.Title == getEvent.Title);

        if (existingEvent == null)
        {
            throw new NotFoundException($"Evento com título '{getEvent.Title}' não encontrado.");
        }

        return existingEvent;
    }
}

       


