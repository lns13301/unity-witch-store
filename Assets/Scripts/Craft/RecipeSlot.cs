using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    [SerializeField] private Image resultImage;
    [SerializeField] private Text resultName;
    [SerializeField] private Text resultCount;
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemObject itemObject;
    [SerializeField] private int sameItemRecipeIndex;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        itemSlot = transform.GetChild(0).GetComponent<ItemSlot>();
        resultImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        resultName = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        resultCount = transform.GetChild(0).GetChild(2).GetComponent<Text>();
        //slotImage = transform.GetChild(2).GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void SetItemObject(ItemObject itemObject, int sameItemRecipeIndex = 0)
    {
        this.sameItemRecipeIndex = sameItemRecipeIndex;
        this.itemObject = itemObject;
        Invoke("Refresh", 0.01f);
    }

    public void Refresh()
    {
        RefreshResult();
        RefreshRecipe(sameItemRecipeIndex);
    }

    private void RefreshResult()
    {
        gameObject.SetActive(true);
        itemSlot.SetItemObject(itemObject);
        resultImage.sprite = itemObject.item.spriteResource.sprite;
        resultName.text = itemObject.item.itemName.GetName(GameManager.instance.PlayerData.language);
        resultCount.text = itemObject.count.ToString();
    }
    
    private void RefreshRecipe(int recipeIndex)
    {
        List<Item> itemCraftRecipes = itemObject.item.itemCraft.recipes[recipeIndex];
        Language language = GameManager.instance.PlayerData.language;
        
        for (int i = 0; i < itemCraftRecipes.Count; i++)
        {
            Item findItemByCode = ItemDatabase.instance.FindItemByCode(itemCraftRecipes[i].code);
            // Deliemeter ???????????? ????????? i * 2 ???????????? ?????? 
            Transform materialSlot = transform.GetChild((i * 2) + 2);

            if (i != 0)
            {
                // '+' ?????? ?????????
                materialSlot.parent.GetChild((i * 2) + 1).gameObject.SetActive(true);
            }
            
            materialSlot.gameObject.SetActive(true);
            materialSlot.GetComponent<ItemSlot>().SetItemObject(new ItemObject(findItemByCode));
            materialSlot.GetChild(0).GetComponent<Image>().sprite = findItemByCode.spriteResource.sprite;
            materialSlot.GetChild(1).GetComponent<Text>().text = findItemByCode.itemName.GetName(language);
            materialSlot.GetChild(2).GetComponent<Text>().text = "1"; // ?????? ?????? ?????? ?????? ??? ????????? ???!
        }
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
