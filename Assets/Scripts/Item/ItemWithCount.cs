using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemWithCount
{
    public Item item;
    public int count;

    public ItemWithCount(Item item, int count = 1)
    {
        this.item = item;
        this.count = count;
    }
}
