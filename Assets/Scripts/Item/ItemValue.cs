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
}
