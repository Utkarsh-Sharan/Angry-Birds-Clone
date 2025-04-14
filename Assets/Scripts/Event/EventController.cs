using System;

public class EventController<T>
{
    public Action<T> GenericActionBaseEvent;
    public void AddListener(Action<T> listener) => GenericActionBaseEvent += listener;
    public void InvokeEvent(T type) => GenericActionBaseEvent?.Invoke(type);
    public void RemoveListener(Action<T> listener) => GenericActionBaseEvent -= listener;
}

public class EventController
{
    public Action ActionBaseEvent;
    public void AddListener(Action listener) => ActionBaseEvent += listener;
    public void InvokeEvent() => ActionBaseEvent?.Invoke();
    public void RemoveListener(Action listener) => ActionBaseEvent -= listener;
}