using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemName
{
    public string english;
    public string korean;

    public ItemName(string english, string korean)
    {
        this.english = english;
        this.korean = korean;
    }
    
    public string GetName(Language language)
    {
        switch (language)
        {
            case Language.KOREAN:
                return korean;
            default:
                return english;
        }
    }
}
