using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSalePriceUI : MonoBehaviour
{
    [SerializeField] private ItemObject itemObject;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject closePanel;
    [SerializeField] private ShopItemUI shopItemUI;
    [SerializeField] private TouchPad touchPad;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        gameObject.SetActive(false);
        animator = GetComponent<Animator>();
        var parent = transform.parent;
        closePanel = parent.Find("CloseShopSalePriceUI").gameObject;
        closePanel.SetActive(false);
        shopItemUI = parent.Find("ShopItemUI").GetComponent<ShopItemUI>();
        touchPad = GetComponent<TouchPad>();
    }

    public void OnSalePriceUI()
    {
        itemObject = shopItemUI.ItemObject;
        
        shopItemUI.OffPanel();
        gameObject.SetActive(true);
        closePanel.SetActive(true);
        animator.SetBool("isUIOn", true);
        touchPad.Refresh(itemObject.item.itemValue.salePrice);
    }

    public void OffSalePriceUI()
    {
        shopItemUI.OnPanel(itemObject);
        SoundManager.instance.PlayOneShotEffectFindByName("ButtonClose");
        animator.SetBool("isUIOn", false);
        Invoke("Off", 0.5f);
        closePanel.SetActive(false);
    }
    
    public void Off()
    {
        gameObject.SetActive(false);
    }

    public void ApplyPrice()
    {
        itemObject.item.itemValue.salePrice = touchPad.Value();
        OffSalePriceUI();
    }
}
