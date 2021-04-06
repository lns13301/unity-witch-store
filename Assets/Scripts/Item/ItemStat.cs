using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStat
{
    public ItemStatConsume itemStatConsume;

    public ItemStat(ItemStatConsume itemStatConsume)
    {
        this.itemStatConsume = itemStatConsume;
    }
}
