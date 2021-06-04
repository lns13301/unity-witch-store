using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyStream<T, R> {
    private List<T> list;

    public MyStream(List<T> list)
    {
        this.list = list;
    }

    public static MyStream<T, R> Of(List<T> list)
    {
        return new MyStream<T, R>(list);
    }

    public MyStream<T, R> Filter(Predicate<T> predicate)
    {
        List<T> result = new List<T>();
        foreach (T t in list) {
            if (predicate(t)) {
                result.Add(t);
            }
        }
        return new MyStream<T, R>(result);
    }

    public MyStream<R, R> Map(Func<T, R> mapper) {
        List<R> result = new List<R>();
        foreach (T t in list) {
            result.Add(mapper(t));
        }
        return new MyStream<R, R>(result);
    }

    public MyStream<T, R> Distinct() {
        return new MyStream<T, R>(new List<T>(new HashSet<T>(list)));
    }

    public List<T> ToList() {
        return new List<T>(list);
    }

    public long Count() {
        return (long) list.Count;
    }

    public void ForEach(Action<T> action) {
        foreach (T t in list) {
            action(t);
        }
    }
}
