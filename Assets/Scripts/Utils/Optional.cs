using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Optional<T> {
    private T value;
    public bool IsPresent { get; private set; } = false;

    private Optional() { }

    public static Optional<T> Empty() {
        return new Optional<T>();
    }

    public static Optional<T> Of(T value) {
        Optional<T> obj = new Optional<T>();
        obj.Set(value);
        return obj;
    }

    public void Set(T value) {
        this.value = value;
        IsPresent = true;
    }

    public T Get() {
        return value;
    }

    
    // For Unity get random chance value.
    public T Get(float chance)
    {
        if (Random.Range(0f, 100f - 0.0000001f) < chance)
        {
            return value;
        }
        return Empty().Get();
    }
}
