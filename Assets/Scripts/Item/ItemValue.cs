using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemValue
{
    public ItemGrade itemGrade;

    public long purchasePrice;
    public long salePrice;

    public ItemValue(ItemGrade itemGrade, long purchasePrice, long salePrice)
    {
        this.itemGrade = itemGrade;
        this.purchasePrice = purchasePrice;
        this.salePrice = salePrice;
    }
}
