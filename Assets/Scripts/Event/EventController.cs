using System;

namespace Event
{
    public class EventController<T>
    {
        public Action<T> GenericActionBaseEvent;
        public void AddListener(Action<T> listener) => GenericActionBaseEvent += listener;
        public void InvokeEvent(T type) => GenericActionBaseEvent?.Invoke(type);
        public void RemoveListener(Action<T> listener) => GenericActionBaseEvent -= listener;
    }

    public class EventController
    {
        public Action BaseEvent;
        public void AddListener(Action listener) => BaseEvent += listener;
        public void InvokeEvent() => BaseEvent?.Invoke();
        public void RemoveListener(Action listener) => BaseEvent -= listener;
    }
}