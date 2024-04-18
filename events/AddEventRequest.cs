namespace ativa_recife.events;

public record AddEventRequest(string Title, 
    string Description,
    DateTime Hour, 
    DateTime Date,
    string Local);