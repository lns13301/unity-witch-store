using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int code;
    public ItemName itemName;
    public SpriteResource spriteResource;

    public ItemValue itemValue;
    public ItemStat itemStat;

    public Item(Item item)
    {
        this.code = item.code;
        this.itemName = item.itemName;
        this.spriteResource = item.spriteResource;
        this.itemValue = item.itemValue;
        this.itemStat = item.itemStat;
    }
    
    public Item(int code, ItemName itemName, SpriteResource spriteResource, ItemValue itemValue)
    {
        this.code = code;
        this.itemName = itemName;
        this.spriteResource = spriteResource;
        this.itemValue = itemValue;
    }
    
    public Item(int code, ItemName itemName, SpriteResource spriteResource, ItemValue itemValue, ItemStat itemStat)
    {
        this.code = code;
        this.itemName = itemName;
        this.spriteResource = spriteResource;
        this.itemValue = itemValue;
        this.itemStat = itemStat;
    }
}
