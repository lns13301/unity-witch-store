using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemCraft
{
    public List<List<Item>> recipes;
    public List<Item> materials;

    public void AddRecipe(List<Item> items)
    {
        recipes.Add(items);
    }

    public void AddMaterial(Item item)
    {
        materials.Add(item);
    }

    public class Builder
    {
        public List<List<Item>> recipes;
        public List<Item> materials;

        public Builder()
        {
        }

        public Builder Recipes(List<List<Item>> recipes)
        {
            this.recipes = recipes;
            return this;
        }

        public Builder Materials(List<Item> materials)
        {
            this.materials = materials;
            return this;
        }

        public ItemCraft build()
        {
            return new ItemCraft(this);
        }
    }

    public ItemCraft(Builder builder)
    {
        this.recipes = builder.recipes;
        this.materials = builder.materials;
    }

    public List<int> FindMaterialCode()
    {
        return MyStream<List<Item>>.Of(recipes)
            .FlatMap(MyStream<Item>.Of)
            .Map(item => item.code)
            .Distinct()
            .ToList();
    }

    // 이 아이템을 만들기 위한 레시피가 존재하는가?
    public bool HasRecipe()
    {
        return recipes.Count > 0;
    }

    // 어떤 아이템의 재료인가?
    public bool HasMaterial()
    {
        return materials.Count > 0;
    }
}