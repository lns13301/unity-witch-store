using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTabImpl : ItemTabStrategy
{
    public void Refresh(List<ItemObject> itemObjects, Transform content)
    {
        content.parent.parent.gameObject.SetActive(true);
        
        for (int i = 0; i < itemObjects.Count; i++)
        {
            content.GetChild(i).gameObject.SetActive(true);
            content.GetChild(i).GetComponent<ShopSlot>().SetItemObject(itemObjects[i]);  // 수정 요망
        }

        for (int i = itemObjects.Count; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }
    }
}
