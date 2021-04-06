using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemObject> itemObjects;
    [SerializeField] private Dictionary<int, int> itemObjectSlotFinder;

    // Start is called before the first frame update
    void Start()
    {
        itemObjects.Add(new ItemObject(
            new Item(100001, new ItemName("Frog Leg", "개구리 다리"), new SpriteResource("Images/Item/Material/FrogLeg"), new ItemValue(ItemGrade.COMMON, 25, 5), new ItemStat(new ItemStatConsume(5))),
            100,
            ItemState.SELL)
            );
        itemObjects.Add(new ItemObject(
            new Item(200001, new ItemName("Red Tonic", "레드 토닉"), new SpriteResource("Images/Item/Potion/RedTonic"), new ItemValue(ItemGrade.RARE, 1000, 200), new ItemStat(new ItemStatConsume(500))),
            100,
            ItemState.SELL)
            );
    }

    // Update is called once per frame
    void Update()
    {
        
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
            return itemObjectSlotFinder[itemCode];
        }
        catch
        {
            return -1;
        }
    }

    // Dictionary
    private void AddItemObjectToFinder(int itemCode)
    {
        itemObjectSlotFinder.Add(itemCode, itemObjects.Count - 1);
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

        itemObjectSlotFinder = refresh;
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
}
