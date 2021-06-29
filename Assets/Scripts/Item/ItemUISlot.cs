using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUISlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text count;
    [SerializeField] private Text price;
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemObject itemObject;

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        count = transform.GetChild(1).GetComponent<Text>();
        price = transform.GetChild(2).GetComponent<Text>();
    }

    public void SetItemObject(ItemObject itemObject)
    {
        this.itemObject = itemObject;
        Invoke("Refresh", 0.01f); // execute order ������ ����Ǵµ� ���� �����ϸ� ������ ��!
    }

    public void Refresh()
    {
        image.sprite = itemObject.item.spriteResource.sprite;
        count.text = itemObject.count.ToString();
        price.text = "평균 판매가 :  " +
                     UtilManager.instance.numberFormatter.ChangeNumberFormat(itemObject.item.itemValue.salePrice) +
                     " 골드";
    }
}
