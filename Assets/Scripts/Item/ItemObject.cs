using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemObject
{
    public Item item;
    public int count;
    public ItemState itemState;

    public ItemObject(ItemObject itemObject)
    {
        item = itemObject.item;
        count = itemObject.count;
    }

    public ItemObject(Item item, int count, ItemState itemState)
    {
        this.item = item;
        this.count = count;
        this.itemState = itemState;
    }

    public void Add(int value)
    {
        count += value;
    }

    public void Remove(int value)
    {
        if (count < value)
        {
            throw new CountOutOfRangeException();
        }

        if (count == value)
        {
            count = 0;
        }
        else
        {
            count -= value;
        }
    }
}
