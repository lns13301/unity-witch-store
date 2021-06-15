using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemValue
{
    public ItemGrade itemGrade;

    public long purchasePrice;
    public long salePrice;
    public double value;

    public ItemValue(ItemGrade itemGrade, long purchasePrice, long salePrice)
    {
        this.itemGrade = itemGrade;
        this.purchasePrice = purchasePrice;
        this.salePrice = salePrice;
        this.value = 0;
    }

    public ItemValue(ItemGrade itemGrade, long purchasePrice, long salePrice, double value)
    {
        this.itemGrade = itemGrade;
        this.purchasePrice = purchasePrice;
        this.salePrice = salePrice;
        this.value = value;
    }

    public class Builder
    {
        public ItemGrade itemGrade;

        public long purchasePrice;
        public long salePrice;
        public double value;

        public Builder()
        {
            itemGrade = global::ItemGrade.COMMON;
            purchasePrice = 0;
            salePrice = 0;
            value = 0;
        }

        public Builder ItemGrade(ItemGrade itemGrade)
        {
            this.itemGrade = itemGrade;
            return this;
        }

        public Builder PurchasePrice(long purchasePrice)
        {
            this.purchasePrice = purchasePrice;
            return this;
        }

        public Builder SalePrice(long salePrice)
        {
            this.salePrice = salePrice;
            return this;
        }

        public Builder Value(double value)
        {
            this.value = value;
            return this;
        }

        public ItemValue build()
        {
            return new ItemValue(this);
        }
    }

    public ItemValue(Builder builder)
    {
        this.itemGrade = builder.itemGrade;
        this.purchasePrice = builder.purchasePrice;
        this.salePrice = builder.salePrice;
        this.value = builder.value;
    }
}