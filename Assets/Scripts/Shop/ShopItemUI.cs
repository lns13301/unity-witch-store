using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    private static string NEW_LINE = "\n";
    
    public static ShopItemUI instance;
    
    [SerializeField] private GameObject panel;
    [SerializeField] private ShopSlot shopSlot;
    [SerializeField] private ShopSlot shopSlotInShop;
    [SerializeField] private Transform contentPanel;
    [SerializeField] private Text price;
    [SerializeField] private Text title;
    [SerializeField] private Text content;
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
        
        shopSlot = transform.GetChild(1).GetComponent<ShopSlot>();
        contentPanel = transform.GetChild(2);
        panel.SetActive(false);
        
        price = shopSlot.transform.Find("Price").GetComponent<Text>();
        content = contentPanel.Find("Content").GetComponent<Text>();
        title = content.transform.Find("Title").GetComponent<Text>();
    }

    public void OnPanel(ShopSlot shopSlot, ItemObject itemObject)
    {
        SoundManager.instance.PlayOneShotSoundFindByName("Paper");
        shopSlotInShop = shopSlot;
        Language language = GameManager.instance.language;
        this.shopSlot.SetItemObject(itemObject);
        price.text = "판매가 : " + itemObject.item.itemValue.salePrice + "골드";
        title.text = itemObject.item.Name(language);
        content.text = "등급 : " +
                       ItemGradeFinder.instance.FindName(itemObject.item.itemValue.itemGrade, language) +
                       NEW_LINE +
                       NEW_LINE +
                       itemObject.item.Content(language);
        panel.SetActive(true);
        animator.SetBool("isUIOn", true);
    }

    public void OffPanel()
    {
        SoundManager.instance.PlayOneShotSoundFindByName("ButtonClose");
        SoundManager.instance.PlayOneShotSoundFindByName("Paper");
        shopSlotInShop.Refresh();
        Invoke("Off", 0.5f);
        animator.SetBool("isUIOn", false);
    }

    public void Off()
    {
        panel.SetActive(false);
    }
}
