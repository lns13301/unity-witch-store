using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftUI : MonoBehaviour, IPointerUpHandler
{
    private static int CONTENT_COUNT = 3;

    public static CraftUI instance;

    public Transform craftContent;
    public Transform recipeContent;
    public Transform inventoryContent;
    public ItemState contentType;

    [SerializeField] private GameObject panel;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private List<ItemObject> itemObjects;
    [SerializeField] private Animator animator;

    private ItemTabStrategy _iTemTabStrategy;
    private RecipeTabImpl _recipeTabImpl;
    private CraftTabImpl _craftTabImpl;
    private InventoryTabImpl _inventoryTabImpl;

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
        gameObject.SetActive(false);

        _recipeTabImpl = new RecipeTabImpl();
        _craftTabImpl = new CraftTabImpl();
        _inventoryTabImpl = new InventoryTabImpl();
        _iTemTabStrategy = _recipeTabImpl;
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

    public void ButtonCraft()
    {
        ApplyInventory(ItemState.CRAFT);
        OnOffPanel(ItemState.CRAFT);
    }

    public void ButtonRecipe()
    {
        ApplyInventory(ItemState.RECIPE);
        OnOffPanel(ItemState.RECIPE);
    }

    public void ButtonInventory()
    {
        ApplyInventory(ItemState.NONE);
        OnOffPanel(ItemState.NONE);
    }

    public void ApplyInventory(ItemState itemState)
    {
        if (itemState == ItemState.CRAFT)
        {
            itemObjects = playerInventory.FindAllItemByCraft();
        }
        else if (itemState == ItemState.RECIPE)
        {
            itemObjects = ItemDatabase.instance.FindAllItemToItemObject();
        }
        else
        {
            itemObjects = playerInventory.FindAllItem(itemState);
        }

        Refresh(itemState);
    }

    public void Refresh()
    {
        Refresh(contentType);
    }

    private void Refresh(ItemState itemState)
    {
        ItemTabStrategy itemTabStrategy;
        Refresh(itemState, ChangeContent(itemState), _iTemTabStrategy);
    }

    private void Refresh(ItemState itemState, Transform content, ItemTabStrategy itemTabStrategy)
    {
        itemTabStrategy.Refresh(itemObjects, content);
    }

    private Transform ChangeContent(ItemState itemState)
    {
        Transform content;

        craftContent.parent.parent.gameObject.SetActive(false);
        recipeContent.parent.parent.gameObject.SetActive(false);
        inventoryContent.parent.parent.gameObject.SetActive(false);

        switch (itemState)
        {
            case ItemState.CRAFT:
                content = craftContent;
                _iTemTabStrategy = _craftTabImpl;
                break;
            case ItemState.RECIPE:
                content = recipeContent;
                _iTemTabStrategy = _recipeTabImpl;
                break;
            default:
                content = inventoryContent;
                _iTemTabStrategy = _inventoryTabImpl;
                break;
        }

        return content;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonCraft();
    }
}