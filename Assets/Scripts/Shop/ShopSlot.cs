using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
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
        Invoke("Refresh", 0.1f); // execute order 오류로 예상되는데 수정 가능하면 수정할 것!
    }

    public void Refresh()
    {
        image.sprite = itemObject.item.spriteResource.sprite;
        count.text = itemObject.count.ToString();
    }

    public void Consume()
    {
        itemObject.Remove(1);
        Refresh();
    }
}
