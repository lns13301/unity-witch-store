using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text name;
    [SerializeField] private Text count;
    [SerializeField] private Image slotImage;

    [SerializeField] private ItemObject itemObject;

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        name = transform.GetChild(1).GetComponent<Text>();
        count = transform.GetChild(2).GetComponent<Text>();
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
    }

    public void OpenItemUI()
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        ItemUI.instance.OnPanel(itemObject);
    }
}
