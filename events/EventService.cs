using ativa_recife.data;
using ativa_recife.Exception;

namespace ativa_recife.events;

public class EventService
{
    private readonly EventRepositoryImp _eventRepository;
    public readonly AppDBContext _appDbContext;

    public EventService(EventRepositoryImp eventRepository)
    {
        _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
     
    }

    public async Task<Event> CreateEvent(Event newEvent)
    {
        if (newEvent == null)
        {
            throw new ArgumentNullException(nameof(newEvent));
        }
        if (_eventRepository._appDbContext == null)
        {
            throw new AppDbContextNotInitializedException("AppDBContext não foi inicializado.");
        }

        if (!_eventRepository._appDbContext.Database.CanConnect())
        {
            throw new NotFoundException("Não foi possível estabelecer conexão com o banco de dados.");
        }

        Event createdEvent = await _eventRepository.Create(newEvent);

        return createdEvent;
    }
    
    public async Task<Event> UpdateEvent(Event updatedEvent)
    {
        if (updatedEvent == null)
        {
            throw new ArgumentNullException(nameof(updatedEvent), "O evento atualizado não pode ser nulo.");
        }

        if (!_eventRepository._appDbContext.Database.CanConnect())
        {
            throw new NotFoundException("Não foi possível estabelecer conexão com o banco de dados.");
        }

        return await _eventRepository.Update(updatedEvent);
    }
    
    public async Task<Event> DeleteEvent(Event eventToDelete)
    {
        if (eventToDelete == null)
        {
            throw new NotFoundException( "O evento a ser excluído não pode ser nulo.");
        }

        // Verifica a conexão com o banco de dados
        if (!_eventRepository._appDbContext.Database.CanConnect())
        {
            throw new NotFoundException("Não foi possível estabelecer conexão com o banco de dados.");
        }

        // Chama o método de exclusão do repositório
        return await _eventRepository.Delete(eventToDelete);
    }
    
    public async Task<Event> GetEventByTitle(Event getEvent)
    {
        // Verifica se o título do evento é válido
        if (string.IsNullOrEmpty(getEvent.Title))
        {
            throw new NotFoundException("O título do evento não pode ser nulo ou vazio.");
        }

        // Chama o método correspondente no repositório para obter o evento pelo título
        var existingEvent = await _eventRepository.GetEventByTitle(getEvent);

        return existingEvent;
    }
}
