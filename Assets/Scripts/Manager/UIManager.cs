using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // Player UI
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateMoney(long money)
    {
        moneyText.text = UtilManager.instance.numberFormatter.ChangeNumberFormat(money);
    }
}