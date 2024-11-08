using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EXList<T> : List<T>
{
    public event UnityAction OnListAddEvent;
    public event UnityAction OnListRemoveEvent;

    public new void Add(T item)
    {
        base.Add(item);
        OnListAddEvent();
    }

    public new void Remove(T item)
    {
        base.Remove(item);
        OnListRemoveEvent();
    }

    public new void RemoveAt(int index)
    {
        base.RemoveAt(index);
        OnListRemoveEvent();
    }
}
