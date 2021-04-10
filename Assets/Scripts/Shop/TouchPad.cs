using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPad : MonoBehaviour
{
    public static TouchPad instance;

    [SerializeField] private Text inputField;
    [SerializeField] private string touchPanelNumberString;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        Initialize();
    }

    private void Initialize()
    {
        inputField = transform.Find("InputPanel").Find("Text").GetComponent<Text>();
    }

    public void Refresh(long value)
    {
        touchPanelNumberString = value.ToString();
        ShowPanelNumber();
    }
    
    private void ShowPanelNumber()
    {
        inputField.text = UtilManager.instance.numberFormatter.ChangeNumberFormat(touchPanelNumberString);
    }
    
    private void RemoveEmptyNumber()
    {
        if (touchPanelNumberString == "0")
        {
            touchPanelNumberString = "";
        }
    }
    
    public void AddZero()
    {
        RemoveEmptyNumber();
        AddValue("0");
        ShowPanelNumber();
    }

    public void AddOne()
    {
        RemoveEmptyNumber();
        AddValue("1");
        ShowPanelNumber();
    }

    public void AddTwo()
    {
        RemoveEmptyNumber();
        AddValue("2");
        ShowPanelNumber();
    }

    public void AddThree()
    {
        RemoveEmptyNumber();
        AddValue("3");
        ShowPanelNumber();
    }

    public void AddFour()
    {
        RemoveEmptyNumber();
        AddValue("4");
        ShowPanelNumber();
    }

    public void AddFive()
    {
        RemoveEmptyNumber();
        AddValue("5");
        ShowPanelNumber();
    }

    public void AddSix()
    {
        RemoveEmptyNumber();
        AddValue("6");
        ShowPanelNumber();
    }

    public void AddSeven()
    {
        RemoveEmptyNumber();
        AddValue("7");
        ShowPanelNumber();
    }

    public void AddEight()
    {
        RemoveEmptyNumber();
        AddValue("8");
        ShowPanelNumber();
    }

    public void AddNine()
    {
        RemoveEmptyNumber();
        AddValue("9");
        ShowPanelNumber();
    }

    private void AddValue(string value)
    {
        if (touchPanelNumberString.Length >= 9)
        {
            return;
        }
        touchPanelNumberString += value;
        SoundManager.instance.PlayOneShotSoundFindByName("Calculator");
    }

    public void RemoveLastNumberText()
    {
        if (touchPanelNumberString != null)
        {
            touchPanelNumberString = "" + (long.Parse(touchPanelNumberString) / 10);
            ShowPanelNumber();
            SoundManager.instance.PlayOneShotSoundFindByName("Calculator");
        }
    }

    public void RemoveAllText()
    {
        if (touchPanelNumberString != null)
        {
            touchPanelNumberString = "0";
            ShowPanelNumber();
            SoundManager.instance.PlayOneShotSoundFindByName("Calculator");
        }
    }

    public long Value()
    {
        return long.Parse(touchPanelNumberString);
    }
}
