using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    
    [SerializeField] private List<Item> items;
    private readonly Dictionary<int, Item> _itemFinder = new Dictionary<int, Item>();
    
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
        _itemFinder.Add(item.code, item);
    }

    // Search
    public Item FindItemByCode(int code)
    {
        return new Item(_itemFinder[code]);
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
            result.Add(_itemFinder[item.code]);
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
        AddItem(new Item(100001,
            new ItemName("Frog Leg", "개구리 다리"),
            new ItemContent("null", "흔한 소재이지만, 다양한 레시피에 사용되는 기초 재료이다."),
            new SpriteResource("Images/Item/Material/FrogLeg"),
            new ItemValue(ItemGrade.COMMON, 15, 5), new ItemStat(new ItemStatConsume(5))));
        
        AddItem(new Item(100002,
            new ItemName("Red Bird Feather", "홍조의 깃털"),
            new ItemContent("null", "붉게 타오르는 불꽃을 빼닮은 특별한 깃털이다."),
            new SpriteResource("Images/Item/Material/RedBirdFeather"), 
            new ItemValue(ItemGrade.UNCOMMON, 125, 80)));
        
        AddItem(new Item(100003, 
            new ItemName("Blue Bird Feather", "청조의 깃털"),
            new ItemContent("null", "흐르는 강물의 맑고 투명한 청색과 같은 고급스러운 깃털이다."),
            new SpriteResource("Images/Item/Material/BlueBirdFeather"),
            new ItemValue(ItemGrade.MAGIC, 625, 200)));
        
        AddItem(new Item(100004,
            new ItemName("Red Cherry Flower", "붉은 앵두 꽃"),
            new ItemContent("null", "봉오리 모양이 마치 탐스러운 앵두를 닮은 아름다운 붉은색 꽃이다."),
            new SpriteResource("Images/Item/Material/RedCherryFlower"),
            new ItemValue(ItemGrade.COMMON, 30, 10)));

        AddItem(new Item(200001, 
            new ItemName("Red Tonic", "레드 토닉"),
            new ItemContent("null", "붉은 꽃을 추출하여 만든 원액을 붉은 깃털로 오랜 시간 정제하여 만든 진한 체력 회복 포션이다."),
            new SpriteResource("Images/Item/Potion/RedTonic"),
            new ItemValue(ItemGrade.RARE, 1500, 750), new ItemStat(new ItemStatConsume(500))));
    }
}
