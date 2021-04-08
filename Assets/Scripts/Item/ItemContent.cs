using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContent
{
    public string english;
    public string korean;

    public ItemContent(string english, string korean)
    {
        this.english = english;
        this.korean = korean;
    }
    
    public string GetContent(Language language)
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
