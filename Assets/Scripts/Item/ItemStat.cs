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

    public class Builder
    {
        public ItemStatConsume itemStatConsume;

        public Builder()
        {
        }

        public Builder ItemStatConsume(ItemStatConsume itemStatConsume)
        {
            this.itemStatConsume = itemStatConsume;
            return this;
        }

        public ItemStat build()
        {
            return new ItemStat(this);
        }
    }

    public ItemStat(Builder builder)
    {
        this.itemStatConsume = builder.itemStatConsume;
    }
}