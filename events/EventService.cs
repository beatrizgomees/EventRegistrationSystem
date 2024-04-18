using System;
using System.Threading.Tasks;
using ativa_recife.data;
using ativa_recife.Exception;
using Microsoft.AspNetCore.Mvc;

namespace ativa_recife.events
{
    public class EventService
    {
        private readonly EventRepositoryImp _eventRepository;

        public EventService(EventRepositoryImp eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        [HttpPost]
        public async Task<Event> CreateEvent([FromBody] Event newEvent)
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

        [HttpPut]
        public async Task<Event> UpdateEvent([FromBody] Event updatedEvent)
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

        [HttpDelete]
        public async Task<Event> DeleteEvent(Event eventToDelete)
        {
            if (eventToDelete == null)
            {
                throw new NotFoundException("O evento a ser excluído não pode ser nulo.");
            }

            if (!_eventRepository._appDbContext.Database.CanConnect())
            {
                throw new NotFoundException("Não foi possível estabelecer conexão com o banco de dados.");
            }

            return await _eventRepository.Delete(eventToDelete);
        }

        [HttpGet]
        public async Task<Event> GetEventByTitle(Event getEvent)
        {
            if (string.IsNullOrEmpty(getEvent.Title))
            {
                throw new NotFoundException("O título do evento não pode ser nulo ou vazio.");
            }

            var existingEvent = await _eventRepository.GetEventByTitle(getEvent);
            return existingEvent;
        }
    }
}
