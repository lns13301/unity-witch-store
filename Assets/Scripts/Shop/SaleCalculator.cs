using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleCalculator : MonoBehaviour
{
    private static float DEFAULT_SALE_VALUE = 1000000;

    public float saleWeight;

    [SerializeField] private float saleSpeed;
    [SerializeField] private ItemObject playerItemObject;
    [SerializeField] private Item defaultItem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize(ItemObject itemObject)
    {
        playerItemObject = itemObject;
        StartCoroutine(nameof(Sale));
    }

    IEnumerator Sale()
    {
        InitializeSale();

        while (playerItemObject != null && playerItemObject.itemState == ItemState.SELL)
        {
            yield return new WaitForSeconds(NextCooldown());
            Sell();
        }
    }

    private void Sell()
    {
        playerItemObject.Remove(1);
        SoundManager.instance.PlayEffectFindByName("SellItem");
        ChangePlayerMoney();
        ShopUI.instance.Refresh();
    }

    private void ChangePlayerMoney()
    {
        PlayerData playerData = GameManager.instance.PlayerData;

        playerData.AddMoney(defaultItem.itemValue.salePrice);
        UIManager.instance.UpdateMoney(playerData.money);
    }

    public void InitializeSale()
    {
        defaultItem = ItemDatabase.instance.FindItemByCode(playerItemObject.item.code);
        saleWeight = SaleWeight();
        saleSpeed = SaleManager.instance.saleSpeed;
    }

    private float NextCooldown()
    {
        try
        {
            return UtilManager.instance.randomGenerator.GenerateIntegerInBound(1000, 10000) / 1000;
        }
        catch
        {
            return DEFAULT_SALE_VALUE;
        }
    }

    private float SaleWeight()
    {
        try
        {
            return defaultItem.itemValue.salePrice / playerItemObject.item.itemValue.salePrice;
        }
        catch
        {
            return 0;
        }
    }
}