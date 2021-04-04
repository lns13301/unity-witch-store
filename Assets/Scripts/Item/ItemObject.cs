using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    public int count;

    public ItemObject(ItemObject itemObject)
    {
        item = itemObject.item;
        count = itemObject.count;
    }

    public ItemObject(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
