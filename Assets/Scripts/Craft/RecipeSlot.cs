using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text count;
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemObject itemObject;

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        count = transform.GetChild(1).GetComponent<Text>();
        slotImage = transform.GetChild(2).GetComponent<Image>();
    }

    public void SetItemObject(ItemObject itemObject)
    {
        this.itemObject = itemObject;
        Invoke("Refresh", 0.01f);
    }

    public void Refresh()
    {
        image.sprite = itemObject.item.spriteResource.sprite;
        count.text = itemObject.count.ToString();
    }

    public void Consume()
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        itemObject.Remove(1);
        Refresh();
    }

    public void OpenShopItemUI()
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        RecipeItemUI.instance.OnPanel(this, itemObject);
    }
}
