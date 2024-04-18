using System.Linq.Expressions;
using System.Threading.Tasks;
using ativa_recife.data;
using ativa_recife.Exception;
using ativa_recife.General;
using Microsoft.EntityFrameworkCore;

namespace ativa_recife.events

{
    public class EventRepositoryImp : GeneralRepository<Event>
    {
        public readonly AppDBContext _appDbContext;

        public EventRepositoryImp(AppDBContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<Event> Create(Event newEvent)
        {
            if (string.IsNullOrEmpty(newEvent.Title))
            {
                throw new ArgumentNullException(nameof(newEvent.Title), "O título do evento não pode ser nulo ou vazio.");
            }

            await _appDbContext.Event.AddAsync(newEvent);
            await _appDbContext.SaveChangesAsync();

            return newEvent;
        }

        public async Task<Event> Update(Event eventObj)
        {
            var existingEvent = await _appDbContext.Event.FindAsync(eventObj.Id);

            if (existingEvent != null)
            {
                existingEvent.Title = eventObj.Title;
                existingEvent.Description = eventObj.Description;
                existingEvent.Date = eventObj.Date;
                existingEvent.Hour = eventObj.Hour;
                existingEvent.Local = eventObj.Local;

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
}
