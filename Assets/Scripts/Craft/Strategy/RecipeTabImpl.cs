using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeTabImpl : ItemTabStrategy
{
    public void Refresh(List<ItemObject> itemObjects, Transform content)
    {
        content.parent.parent.gameObject.SetActive(true);

        int index = 0;
        foreach (ItemObject itemObject in itemObjects)
        {
            index = RegisterItemIfHasRecipe(itemObject, content, index);
        }

        for (int i = itemObjects.Count; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }
    }

    private int RegisterItemIfHasRecipe(ItemObject itemObject, Transform content, int contentTransformIndex)
    {
        if (itemObject.item.itemCraft.HasRecipe())
        {
            Transform targetSlot = content.GetChild(contentTransformIndex);
            targetSlot.gameObject.SetActive(true);
            targetSlot.GetComponent<RecipeSlot>().SetItemObject(itemObject);
            return contentTransformIndex + 1;
        }

        return contentTransformIndex;
    }
}
