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
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        playerItemObject = GetComponent<ItemObject>();
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
        // 플레이어 돈 변화
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
