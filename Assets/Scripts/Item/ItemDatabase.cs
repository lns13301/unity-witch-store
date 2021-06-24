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
                new ItemName.Builder().English("Frog Leg").Korean("개구리 다리").build(),
                new ItemContent.Builder().English("null").Korean("흔한 소재이지만, 다양한 레시피에 사용되는 기초 재료이다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(15).SalePrice(5).build(),
                new SpriteResource("Images/Item/Material/FrogLeg"))
            .ItemStat(new ItemStat.Builder().ItemStatConsume(new ItemStatConsume.Builder().RecoveryHP(5).build()).build())
            .build());

        AddItem(new Item.Builder(100002,
                new ItemName.Builder().English("Red Bird Feather").Korean("홍조의 깃털").build(),
                new ItemContent.Builder().English("null").Korean("붉게 타오르는 불꽃을 빼닮은 특별한 깃털이다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.UNCOMMON).PurchasePrice(125).SalePrice(80).build(),
                new SpriteResource("Images/Item/Material/RedBirdFeather"))
            .build());

        AddItem(new Item.Builder(100003,
                new ItemName.Builder().English("Blue Bird Feather").Korean("청조의 깃털").build(),
                new ItemContent.Builder().English("null").Korean("흐르는 강물의 맑고 투명한 청색과 같은 고급스러운 깃털이다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.MAGIC).PurchasePrice(625).SalePrice(200).build(),
                new SpriteResource("Images/Item/Material/BlueBirdFeather"))
            .build());

        AddItem(new Item.Builder(100004,
                new ItemName.Builder().English("Red Cherry Flower").Korean("붉은 앵두 꽃").build(),
                new ItemContent.Builder().English("null").Korean("봉오리 모양이 마치 탐스러운 앵두를 닮은 아름다운 붉은색 꽃이다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(30).SalePrice(10).build(),
                new SpriteResource("Images/Item/Material/RedCherryFlower"))
            .build());

        AddItem(new Item.Builder(100005,
                new ItemName.Builder().English("Leaves").Korean("잎사귀").build(),
                new ItemContent.Builder().English("null").Korean("푸른 빛갈이 감도는 싱싱한 식물의 잎사귀다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.COMMON).PurchasePrice(20).SalePrice(8).build(),
                new SpriteResource("Images/Item/Material/Leaves"))
            .build());
        
        AddItem(new Item.Builder(100006,
                new ItemName.Builder().English("PointedFangs").Korean("뾰족한 송곳니").build(),
                new ItemContent.Builder().English("null").Korean("꽤나 딱딱하지만 미끈한 재질을 가진 송곳니다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.UNCOMMON).PurchasePrice(250).SalePrice(100).build(),
                new SpriteResource("Images/Item/Material/PointedFangs"))
            .build());

        AddItem(new Item.Builder(200001,
                new ItemName.Builder().English("Red Tonic").Korean("레드 토닉").build(),
                new ItemContent.Builder().English("null").Korean("붉은 꽃을 추출하여 만든 원액을 붉은 깃털로 오랜 시간 정제하여 만든 진한 체력 회복 포션이다.").build(),
                new ItemValue.Builder().ItemGrade(ItemGrade.RARE).PurchasePrice(1500).SalePrice(750).build(),
                new SpriteResource("Images/Item/Consume/RedTonic"))
            .ItemStat(new ItemStat.Builder().ItemStatConsume(new ItemStatConsume.Builder().RecoveryHP(300).build()).build())
            .build());

        InitializeRecipes();
        InitializeMaterials();
    }

    private void InitializeRecipes()
    {
        FindItem("레드 토닉").AddRecipe(new ItemCraft.Builder().Recipes(
            new List<List<Item>>()
            {
                new List<Item>() {FindItem("잎사귀"), FindItem("붉은 앵두 꽃")},
                new List<Item>() {FindItem("잎사귀"), FindItem("잎사귀"), FindItem("잎사귀")},
            }
        ).build());
        
        Debug.Log(FindItem("레드 토닉").itemCraft.recipes.Count);
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