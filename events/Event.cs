namespace ativa_recife.events;

public class Event
{
    public Guid Id { get; init; }
    public string Title {  get; set; }
    public string Description { set; get; }
    public DateTime Date {  set; get; }
    public DateTime Hour {  set; get; }
    public string Local { set; get; }

    public Event(string title, string description, DateTime date, DateTime hour, string local)
    {
        this.Title = title;
        this.Description = description;
        this.Date = date;
        this.Hour = hour;
        this.Local = local;

        Id = Guid.NewGuid();
        
    }

    public Event()
    {
        throw new NotImplementedException();
    }
}