using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    [SerializeField] private List<Item> items;
    private readonly Dictionary<int, Item> _itemFinderByCode = new Dictionary<int, Item>();
    private readonly Dictionary<string, Item> _itemFinderByName = new Dictionary<string, Item>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Register
    private void AddItem(Item item)
    {
        items.Add(item);
        _itemFinderByCode.Add(item.code, item);
        _itemFinderByName.Add(item.Name(Language.KOREAN), item);
        _itemFinderByName.Add(item.Name(Language.ENGLISH), item);
    }

    // Search
    public Item FindItemByCode(int code)
    {
        return new Item(_itemFinderByCode[code]);
    }

    public Item FindItemByName(string name)
    {
        return new Item(_itemFinderByName[name]);
    }
    
    private Item FindItem(int code)
    {
        return _itemFinderByCode[code];
    }

    private Item FindItem(string name)
    {
        return _itemFinderByName[name];
    }

    public List<Item> FindAllItems()
    {
        return new List<Item>(items);
    }

    public List<Item> FindAllItems(List<Item> items)
    {
        List<Item> result = new List<Item>();

        foreach (Item item in items)
        {
            result.Add(_itemFinderByCode[item.code]);
        }

        return result;
    }

    public List<Item> FindAllItems(List<int> itemCodes)
    {
        List<Item> result = new List<Item>();

        foreach (var code in itemCodes)
        {
            result.Add(FindItemByCode(code));
        }

        return result;
    }
    
    public List<ItemObject> FindAllItemToItemObject()
    {
        List<ItemObject> result = new List<ItemObject>();

        foreach (Item item in items)
        {
            result.Add(new ItemObject(item, 1));
        }

        return result;
    }

    public List<ItemObject> FindAllItemToItemObject(Dictionary<int, int> itemCodeAndCounts)
    {
        List<ItemObject> result = new List<ItemObject>();

        foreach (KeyValuePair<int, int> element in itemCodeAndCounts)
        {
            result.Add(new ItemObject(FindItemByCode(element.Key), element.Value));
        }

        return result;
    }

    // File IO
    private void Save()
    {
    }

    private void Load()
    {
    }

    // Test
    private void Initialize()
    {
        AddItem(new Item.Builder(100001,
                new ItemName.Builder().English("Frog Leg").Korean("????????? ??????").build(),
                new ItemContent.Builder().English("null").Korean("?????? ???????????????, ????????? ???????????? ???????????? ?????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(15).SalePrice(5).build(),
                new SpriteResource("Images/Item/Material/FrogLeg"))
            .ItemStat(new ItemStat.Builder().ItemStatConsume(new ItemStatConsume.Builder().RecoveryHP(5).build()).build())
            .build());

        AddItem(new Item.Builder(100002,
                new ItemName.Builder().English("Red Bird Feather").Korean("????????? ??????").build(),
                new ItemContent.Builder().English("null").Korean("?????? ???????????? ????????? ????????? ????????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.UNCOMMON).PurchasePrice(125).SalePrice(80).build(),
                new SpriteResource("Images/Item/Material/RedBirdFeather"))
            .build());

        AddItem(new Item.Builder(100003,
                new ItemName.Builder().English("Blue Bird Feather").Korean("????????? ??????").build(),
                new ItemContent.Builder().English("null").Korean("????????? ????????? ?????? ????????? ????????? ?????? ??????????????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.MAGIC).PurchasePrice(625).SalePrice(200).build(),
                new SpriteResource("Images/Item/Material/BlueBirdFeather"))
            .build());

        AddItem(new Item.Builder(100004,
                new ItemName.Builder().English("Red Cherry Flower").Korean("?????? ?????? ???").build(),
                new ItemContent.Builder().English("null").Korean("????????? ????????? ?????? ???????????? ????????? ?????? ???????????? ????????? ?????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(30).SalePrice(10).build(),
                new SpriteResource("Images/Item/Material/RedCherryFlower"))
            .build());

        AddItem(new Item.Builder(100005,
                new ItemName.Builder().English("Leaves").Korean("?????????").build(),
                new ItemContent.Builder().English("null").Korean("?????? ????????? ????????? ????????? ????????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(20).SalePrice(8).build(),
                new SpriteResource("Images/Item/Material/Leaves"))
            .build());
        
        AddItem(new Item.Builder(100006,
                new ItemName.Builder().English("PointedFangs").Korean("????????? ?????????").build(),
                new ItemContent.Builder().English("null").Korean("?????? ??????????????? ????????? ????????? ?????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.UNCOMMON).PurchasePrice(250).SalePrice(100).build(),
                new SpriteResource("Images/Item/Material/PointedFangs"))
            .build());

        AddItem(new Item.Builder(200001,
                new ItemName.Builder().English("Red Tonic").Korean("?????? ??????").build(),
                new ItemContent.Builder().English("null").Korean("?????? ?????? ???????????? ?????? ????????? ?????? ????????? ?????? ?????? ???????????? ?????? ?????? ?????? ?????? ????????????.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.RARE).PurchasePrice(1500).SalePrice(750).build(),
                new SpriteResource("Images/Item/Consume/RedTonic"))
            .ItemStat(new ItemStat.Builder().ItemStatConsume(new ItemStatConsume.Builder().RecoveryHP(300).build()).build())
            .build());

        InitializeRecipes();
        InitializeMaterials();
    }

    private void InitializeRecipes()
    {
        FindItem("?????? ??????").AddRecipe(new ItemCraft.Builder().Recipes(
            new List<List<Item>>()
            {
                new List<Item>() {FindItem("?????????"), FindItem("?????? ?????? ???")},
                new List<Item>() {FindItem("?????????"), FindItem("?????????"), FindItem("?????????"), FindItem("????????? ??????")},
            }
        ).build());
        FindItem("????????? ??????").AddRecipe(new ItemCraft.Builder().Recipes(
            new List<List<Item>>()
            {
                new List<Item>() {FindItem("????????? ??????"), FindItem("?????? ??????")},
            }
        ).build());
        FindItem("?????????").AddRecipe(new ItemCraft.Builder().Recipes(
            new List<List<Item>>()
            {
                new List<Item>() {FindItem("????????? ?????????"), FindItem("?????? ?????? ???")},
            }
        ).build());
        FindItem("????????? ??????").AddRecipe(new ItemCraft.Builder().Recipes(
            new List<List<Item>>()
            {
                new List<Item>() {FindItem("????????? ?????????")},
            }
        ).build());
        
        Debug.Log(FindItem("?????? ??????").itemCraft.recipes.Count);
    }

    private void InitializeMaterials()
    {
        foreach (Item item in items)
        {
            PutMaterials(item);
        }
    }

    private void PutMaterials(Item item)
    {
        if (item.itemCraft == null)
        {
            return;
        }
        List<int> findMaterialCode = item.itemCraft.FindMaterialCode();

        foreach (int code in findMaterialCode)
        {
            Item material = FindItem(code);
            material.AddMaterial(item);
        }
    }
}