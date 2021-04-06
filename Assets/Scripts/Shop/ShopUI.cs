using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;

    public Transform content;

    [SerializeField] private GameObject panel;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private List<ItemObject> itemObjects;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panel = gameObject;

        SoundManager.instance.PlayMusicFindByName("Bird");
        SoundManager.instance.PlayMusicFindByName("Shop");

        playerInventory = GameObject.Find("Manager").transform.Find("PlayerInventoryManager").GetComponent<Inventory>();
        ApplyPlayerInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOffPanel()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void ApplyPlayerInventory()
    {
        itemObjects = playerInventory.FindAllItem(ItemState.SELL);
        Refresh();
    }

    private void Refresh()
    {
        for (int i = 0; i < itemObjects.Count; i++)
        {
            content.GetChild(i).gameObject.SetActive(true);
            content.GetChild(i).GetComponent<ShopSlot>().SetItemObject(itemObjects[i]);
        }

        for (int i = itemObjects.Count; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }
    }
}
