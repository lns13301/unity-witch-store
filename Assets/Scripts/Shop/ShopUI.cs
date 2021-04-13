using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private static int CONTENT_COUNT = 3;
    
    public static ShopUI instance;

    public Transform saleContent;
    public Transform purchaseContent;
    public Transform inventoryContent;
    public ItemState contentType;

    [SerializeField] private GameObject panel;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private List<ItemObject> itemObjects;
    [SerializeField] private Animator animator;

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

    private void Initialize()
    {
        panel = gameObject;
        animator = GetComponent<Animator>();

        SoundManager.instance.PlayMusicFindByName("Bird");
        SoundManager.instance.PlayMusicFindByName("Shop");

        playerInventory = GameObject.Find("Manager").transform.Find("PlayerInventoryManager").GetComponent<Inventory>();
        ApplyInventory(contentType); // 테스트용
    }

    public void OnOffPanel()
    {
        animator.SetBool("isUIOn", !animator.GetBool("isUIOn"));
        SoundManager.instance.PlayOneShotSoundFindByName("BubblePop");
    }

    public void ButtonSale()
    {
        ApplyInventory(ItemState.SELL);
        OnOffPanel();
    }
    
    public void ButtonPurchase()
    {
        ApplyInventory(ItemState.BUY);
        OnOffPanel();
    }
    
    public void ButtonInventory()
    {
        ApplyInventory(ItemState.NONE);
        OnOffPanel();
    }

    public void ApplyInventory(ItemState itemState)
    {
        itemObjects = playerInventory.FindAllItem(itemState);
        Refresh(itemState);
    }
    
    private void Refresh(ItemState itemState)
    {
        Transform content = ChangeContent(itemState);

        if (animator.GetBool("isUIOn"))
        {
            return;
        }
        
        content.parent.parent.gameObject.SetActive(true);
        
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

    private Transform ChangeContent(ItemState itemState)
    {
        Transform content;
        
        saleContent.parent.parent.gameObject.SetActive(false);
        purchaseContent.parent.parent.gameObject.SetActive(false);
        inventoryContent.parent.parent.gameObject.SetActive(false);
        
        switch (itemState)
        {
            case ItemState.SELL:
                content = saleContent;
                break;
            case ItemState.BUY:
                content = purchaseContent;
                break;
            default: 
                content = inventoryContent;
                break;
        }

        return content;
    }
}
