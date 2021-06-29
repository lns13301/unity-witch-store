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

        playerInventory = GameObject.Find("Manager").transform.Find("PlayerInventoryManager").GetComponent<Inventory>();
        //ApplyInventory(contentType); // 테스트용
    }

    public void OnOffPanel(ItemState contentType)
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");

        if (this.contentType != contentType && animator.GetBool("isUIOn"))
        {
            this.contentType = contentType;
            return;
        }

        this.contentType = contentType;
        animator.SetBool("isUIOn", !animator.GetBool("isUIOn"));
    }

    public void ButtonSale()
    {
        ApplyInventory(ItemState.SELL);
        OnOffPanel(ItemState.SELL);
    }

    public void ButtonPurchase()
    {
        ApplyInventory(ItemState.BUY);
        OnOffPanel(ItemState.BUY);
    }

    public void ButtonInventory()
    {
        ApplyInventory(ItemState.NONE);
        OnOffPanel(ItemState.NONE);
    }

    public void ApplyInventory(ItemState itemState)
    {
        itemObjects = playerInventory.FindAllItem(itemState);
        Refresh(itemState);
    }

    public void Refresh()
    {
        Refresh(contentType);
    }

    private void Refresh(ItemState itemState)
    {
        Transform content = ChangeContent(itemState);

        content.parent.parent.gameObject.SetActive(true);

        for (int i = 0; i < itemObjects.Count; i++)
        {
            content.GetChild(i).gameObject.SetActive(true);
            content.GetChild(i).GetComponent<ShopSlot>().SetItemObject(itemObjects[i]);
            if (itemState == ItemState.SELL)
            {
                content.GetChild(i).GetComponent<SaleCalculator>().Initialize(itemObjects[i]);
            }
        }

        for (int i = itemObjects.Count; i < content.childCount; i++)
        {
            content.GetChild(i).gameObject.SetActive(false);
        }

        ShopItemUI.instance.Refresh();
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