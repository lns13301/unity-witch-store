using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int code;
    public ItemName itemName;
    public SpriteResource spriteResource;

    public ItemValue ItemValue;
    public ItemStat itemStat;

    public Item(int code, ItemName itemName, SpriteResource spriteResource, ItemValue itemValue, ItemStat itemStat)
    {
        this.code = code;
        this.itemName = itemName;
        this.spriteResource = spriteResource;
        ItemValue = itemValue;
        this.itemStat = itemStat;
    }
}
