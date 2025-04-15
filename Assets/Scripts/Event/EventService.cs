namespace Event
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public EventController OnBirdLeftSlingshotEvent { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            InitializeEvents();
        }

        private void InitializeEvents()
        {
            OnBirdLeftSlingshotEvent = new EventController();
        }
    }
}