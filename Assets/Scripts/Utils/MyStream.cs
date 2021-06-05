using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class MyStream<T>
{
    private List<T> list;

    private MyStream(List<T> list)
    {
        this.list = list;
    }

    public static MyStream<T> Of(List<T> list)
    {
        return new MyStream<T>(list);
    }

    public MyStream<T> Filter(Predicate<T> predicate)
    {
        List<T> result = new List<T>();
        foreach (T t in list)
        {
            if (predicate(t))
            {
                result.Add(t);
            }
        }

        return new MyStream<T>(result);
    }

    public MyStream<R> Map<R>(Func<T, R> mapper)
    {
        List<R> result = new List<R>();
        foreach (T t in list)
        {
            result.Add(mapper(t));
        }

        return new MyStream<R>(result);
    }

    public MyStream<R> FlatMap<R>(Func<T, MyStream<R>> mapper)
    {
        List<R> result = new List<R>();
        foreach (T t in list)
        {
            MyStream<R> apply = mapper(t);
            apply.ForEach(x => result.Add(x));
        }

        return new MyStream<R>(result);
    }

    public MyStream<T> Distinct()
    {
        return new MyStream<T>(new List<T>(new HashSet<T>(list)));
    }

    public MyStream<T> Limit(int count)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(list[i]);
        }

        return new MyStream<T>(result);
    }

    public MyStream<T> Shuffle()
    {
        List<T> list = new List<T>(this.list);
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = new Random().Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return new MyStream<T>(list);
    }

    public Optional<T> FindAny()
    {
        return Optional<T>.Of(list[0]);
    }

    public List<T> ToList()
    {
        return new List<T>(list);
    }

    public long Count()
    {
        return (long) list.Count;
    }

    public void ForEach(Action<T> action)
    {
        foreach (T t in list)
        {
            action(t);
        }
    }
}