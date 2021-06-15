using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int code;
    public ItemName itemName;
    public ItemContent itemContent;
    public SpriteResource spriteResource;

    public ItemValue itemValue;
    public ItemStat itemStat;

    public ItemCraft itemCraft;

    public Item(Item item)
    {
        this.code = item.code;
        this.itemName = item.itemName;
        this.itemContent = item.itemContent;
        this.spriteResource = item.spriteResource;
        this.itemValue = item.itemValue;
        this.itemStat = item.itemStat;
        this.itemCraft = item.itemCraft;
    }

    public Item(int code, ItemName itemName, ItemContent itemContent, SpriteResource spriteResource,
        ItemValue itemValue)
    {
        this.code = code;
        this.itemName = itemName;
        this.itemContent = itemContent;
        this.spriteResource = spriteResource;
        this.itemValue = itemValue;
    }

    public Item(int code, ItemName itemName, ItemContent itemContent, SpriteResource spriteResource,
        ItemValue itemValue, ItemStat itemStat)
    {
        this.code = code;
        this.itemName = itemName;
        this.itemContent = itemContent;
        this.spriteResource = spriteResource;
        this.itemValue = itemValue;
        this.itemStat = itemStat;
    }

    public class Builder
    {
        public int code;
        public ItemName itemName;
        public ItemContent itemContent;
        public SpriteResource spriteResource;

        public ItemValue itemValue;
        public ItemStat itemStat;

        public ItemCraft itemCraft;

        public Builder(int code, ItemName itemName, ItemContent itemContent, ItemValue itemValue, SpriteResource spriteResource)
        {
            this.code = code;
            this.itemName = itemName;
            this.itemContent = itemContent;
            this.spriteResource = spriteResource;
            this.itemValue = itemValue;
            this.itemCraft = new ItemCraft.Builder().build();
        }

        public Builder ItemStat(ItemStat itemStat)
        {
            this.itemStat = itemStat;
            return this;
        }

        public Builder ItemCraft(ItemCraft itemCraft)
        {
            this.itemCraft = itemCraft;
            return this;
        }

        public Item build()
        {
            return new Item(this);
        }
    }

    public Item(Builder builder)
    {
        this.code = builder.code;
        this.itemName = builder.itemName;
        this.itemContent = builder.itemContent;
        this.spriteResource = builder.spriteResource;
        this.itemValue = builder.itemValue;
        this.itemStat = builder.itemStat;
        this.itemCraft = builder.itemCraft;
    }

    public string Name(Language language)
    {
        switch (language)
        {
            case Language.KOREAN:
                return itemName.korean;
            default:
                return itemName.english;
        }
    }

    public string Content(Language language)
    {
        switch (language)
        {
            case Language.KOREAN:
                return itemContent.korean;
            default:
                return itemContent.english;
        }
    }

    public void AddRecipe(ItemCraft craft)
    {
        itemCraft = new ItemCraft.Builder().Recipes(craft.recipes).build();
    }
    
    public void AddMaterial(Item item)
    {
        itemCraft.AddMaterial(item);
    }
}