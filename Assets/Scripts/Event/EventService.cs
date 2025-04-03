public class EventService : GenericMonoSingleton<EventService>
{
    protected override void Awake()
    {
        base.Awake();

        InitializeEvents();
    }

    private void InitializeEvents()
    {
        
    }
}
