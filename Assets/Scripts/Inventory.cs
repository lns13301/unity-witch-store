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
        // 임시 아이템 생성 및 로드 테스트, 후에 playerData 를 통해서 주입 받도록 변경, CountOutOfRange 예외 처리 해결
        Dictionary<int, int> testItemTable = new Dictionary<int, int>();
        testItemTable.Add(100001, 150);
        testItemTable.Add(100002, 330);
        testItemTable.Add(100003, 565);
        testItemTable.Add(100004, 2104);
        testItemTable.Add(100005, 333);
        testItemTable.Add(100006, 222);
        testItemTable.Add(200001, 412);

        itemObjects = ItemDatabase.instance.FindAllItemToItemObject(testItemTable);

        foreach (ItemObject itemObject in itemObjects)
        {
            itemObject.itemState = ItemState.SELL;
        }

        itemObjects[0].itemState = ItemState.BUY;
        itemObjects[4].itemState = ItemState.NONE;
        itemObjects[5].itemState = ItemState.NONE;
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
            SetItemObject(target,
                new ItemObject(itemObject.item, target.count - itemObject.count, itemObject.itemState));
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

    public List<ItemObject> FindAllItemByCraft()
    {
        List<ItemObject> result = new List<ItemObject>();
        List<ItemObject> found = FindAllItem(ItemState.NONE);

        foreach (ItemObject itemObject in found)
        {
            if (itemObject.item.itemCraft.HasRecipe())
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