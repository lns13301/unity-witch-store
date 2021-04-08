using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemUI : MonoBehaviour
{
    public static ShopItemUI instance;
    
    [SerializeField] private GameObject panel;
    [SerializeField] private ShopSlot shopSlot;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panel = gameObject;
        shopSlot = transform.GetChild(1).GetComponent<ShopSlot>();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPanel(ItemObject itemObject)
    {
        shopSlot.SetItemObject(itemObject);
        panel.SetActive(true);
    }

    public void OffPanel()
    {
        panel.SetActive(false);
    }
}
