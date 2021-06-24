using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private Image resultImage;
    [SerializeField] private Text resultName;
    [SerializeField] private Text resultCount;
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemObject itemObject;

    private void Start()
    {
        resultImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        resultName = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        resultCount = transform.GetChild(0).GetChild(2).GetComponent<Text>();
        //slotImage = transform.GetChild(2).GetComponent<Image>();
    }

    public void SetItemObject(ItemObject itemObject)
    {
        this.itemObject = itemObject;
        Invoke("Refresh", 0.01f);
    }

    public void Refresh()
    {
        resultImage.sprite = itemObject.item.spriteResource.sprite;
        resultName.text = itemObject.item.itemName.GetName(GameManager.instance.PlayerData.language);
        resultCount.text = itemObject.count.ToString();
    }

    public void Consume()
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        itemObject.Remove(1);
        Refresh();
    }

    public void OpenCraftItemUI()
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        RecipeItemUI.instance.OnPanel(this, itemObject);
    }
}
