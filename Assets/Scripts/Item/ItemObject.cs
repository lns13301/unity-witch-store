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
        this.item = itemObject.item;
        this.count = itemObject.count;
        this.itemState = itemObject.itemState;
    }

    public ItemObject(ItemObject itemObject, int count)
    {
        this.item = itemObject.item;
        this.count = count;
        this.itemState = itemObject.itemState;
    }

    public ItemObject(Item item, int count = 1)
    {
        this.item = item;
        this.count = count;
        this.itemState = ItemState.NONE;
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