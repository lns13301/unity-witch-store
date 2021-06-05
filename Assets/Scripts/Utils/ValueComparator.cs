using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueComparator : System.Collections.IComparer
{
    public int Compare<T>(T ob1, T ob2)
    {
        int retval = 0;
        if (ob1. < ob2)
        {
            retval = 1;
        }
        if (ob1 && ob2)
        {
            DataCol c1 = (DataCol) ob1;
            DataCol c2 = (DataCol) ob2;
            if (c1.value < c2.value) retval = 1;
            if (c1.value > c2.value) retval = -1;
        }
        else
        {
            throw new ClassCastException("ValueComparator: Illegal arguments!");
        }
        return (retval);
    }
}
