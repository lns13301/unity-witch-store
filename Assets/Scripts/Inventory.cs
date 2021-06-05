using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemObject> itemObjects;
    private Dictionary<int, int> _itemObjectSlotFinder = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeItemTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeItemTest()
    {
        // 임시 아이템 생성 및 로드 테스트
        Dictionary<int, int> testItemTable = new Dictionary<int, int>();
        testItemTable.Add(100001, 50);
        testItemTable.Add(100002, 30);
        testItemTable.Add(100003, 65);
        testItemTable.Add(100004, 104);
        testItemTable.Add(200001, 12);

        itemObjects = ItemDatabase.instance.FindAllItemToItemObject(testItemTable);

        foreach (ItemObject itemObject in itemObjects)
        {
            itemObject.itemState = ItemState.SELL;
        }

        itemObjects[0].itemState = ItemState.BUY;
    }

    // List
    public void AddItemObject(ItemObject itemObject)
    {
        if (FindItemObjectSlotIndex(itemObject.item.code) == -1)
        {
            itemObjects.Add(itemObject);
            AddItemObjectToFinder(itemObject.item.code);
        }
    }

    public void RemoveItemObject(ItemObject itemObject)
    {
        ItemObject target = itemObjects[FindItemObjectSlotIndex(itemObject.item.code)];

        if (target.count < itemObject.count)
        {
            throw new CountOutOfRangeException();
        }

        if (target.count == itemObject.count)
        {
            itemObjects.RemoveAt(FindItemObjectSlotIndex(itemObject.item.code));
            RemoveItemObjectToFinder();
        }
        else
        {
            SetItemObject(target, new ItemObject(itemObject.item, target.count - itemObject.count, itemObject.itemState));
        }
    }

    private void SetItemObject(int slotIndex, ItemObject itemObject)
    {
        itemObjects[slotIndex] = new ItemObject(itemObject);
    }

    private void SetItemObject(ItemObject target, ItemObject itemObject)
    {
        target = new ItemObject(itemObject);
    }

    public int FindItemObjectSlotIndex(int itemCode)
    {
        try
        {
            return _itemObjectSlotFinder[itemCode];
        }
        catch
        {
            return -1;
        }
    }

    // Dictionary
    private void AddItemObjectToFinder(int itemCode)
    {
        _itemObjectSlotFinder.Add(itemCode, itemObjects.Count - 1);
    }

    private void RemoveItemObjectToFinder()
    {
        RefreshItemObjectSlotIndex();
    }

    private void RefreshItemObjectSlotIndex()
    {
        Dictionary<int, int> refresh = new Dictionary<int, int>();

        
        for (int i = 0; i < itemObjects.Count; i++)
        {
            refresh.Add(itemObjects[i].item.code, i);
        }

        _itemObjectSlotFinder = refresh;
    }

    // Search
    public List<ItemObject> FindAllItem()
    {
        return new List<ItemObject>(itemObjects);
    }

    public List<ItemObject> FindAllItem(ItemState itemState)
    {
        List<ItemObject> result = new List<ItemObject>();

        foreach (ItemObject itemObject in itemObjects)
        {
            if (itemObject.itemState.Equals(itemState))
            {
                result.Add(itemObject);
            }
        }

        return result;
    }
    
    // File IO
    public void Save()
    {
        
    }
    
    public void Load()
    {
        
    }
}
