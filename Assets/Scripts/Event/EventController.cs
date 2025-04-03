using System;

public class EventController<T>
{
    public Action<T> GenericActionBaseEvent;
    public void AddListener(Action<T> listener) => GenericActionBaseEvent += listener;
    public void Invoke(T type) => GenericActionBaseEvent?.Invoke(type);
    public void RemoveListener(Action<T> listener) => GenericActionBaseEvent -= listener;
}
