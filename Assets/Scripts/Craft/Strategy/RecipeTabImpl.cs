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
        ItemCraft itemCraft = itemObject.item.itemCraft;
        if (itemCraft.HasRecipe())
        {
            int recipesCount = itemCraft.recipes.Count;
            
            for (int i = 0; i < recipesCount; i++)
            {
                Transform targetSlot = content.GetChild(contentTransformIndex + i);
                targetSlot.gameObject.SetActive(true);
                targetSlot.GetComponent<RecipeSlot>().SetItemObject(itemObject, i);
            }
            return contentTransformIndex + recipesCount;
        }

        return contentTransformIndex;
    }
}
