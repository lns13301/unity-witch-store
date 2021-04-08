using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    
    [SerializeField] private List<Item> items;
    private Dictionary<int, Item> _itemFinder = new Dictionary<int, Item>();
    
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
    private Item FindItemByCode(int code)
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
            new SpriteResource("Images/Item/Material/FrogLeg"),
            new ItemValue(ItemGrade.COMMON, 25, 5), new ItemStat(new ItemStatConsume(5))));
        
        AddItem(new Item(100002,
            new ItemName("Red Bird Feather", "홍조의 깃털"),
            new SpriteResource("Images/Item/Material/RedBirdFeather"), 
            new ItemValue(ItemGrade.UNCOMMON, 25, 5)));
        
        AddItem(new Item(100003, 
            new ItemName("Blue Bird Feather", "청조의 깃털"),
            new SpriteResource("Images/Item/Material/BlueBirdFeather"),
            new ItemValue(ItemGrade.MAGIC, 25, 5)));
        
        AddItem(new Item(100004,
            new ItemName("Red Cherry Flower", "붉은 앵두 꽃"),
            new SpriteResource("Images/Item/Material/RedCherryFlower"),
            new ItemValue(ItemGrade.COMMON, 25, 5)));

        AddItem(new Item(200001, 
            new ItemName("Red Tonic", "레드 토닉"),
            new SpriteResource("Images/Item/Potion/RedTonic"),
            new ItemValue(ItemGrade.RARE, 1000, 200), new ItemStat(new ItemStatConsume(500))));
    }
}
