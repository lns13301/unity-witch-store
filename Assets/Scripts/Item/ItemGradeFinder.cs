using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGradeFinder : MonoBehaviour
{
    public static ItemGradeFinder instance;

    void Start()
    {
        instance = this;
    }

    public string FindName(ItemGrade itemGrade, Language language)
    {
        switch (itemGrade)
        {
            case ItemGrade.COMMON:
                switch (language)
                {
                    case Language.KOREAN:
                        return "평범";
                    default:
                        return "Common";
                }
            case ItemGrade.UNCOMMON:
                switch (language)
                {
                    case Language.KOREAN:
                        return "비범";
                    default:
                        return "Uncommon";
                }
            case ItemGrade.MAGIC:
                switch (language)
                {
                    case Language.KOREAN:
                        return "마법";
                    default:
                        return "Magic";
                }
            case ItemGrade.RARE:
                switch (language)
                {
                    case Language.KOREAN:
                        return "희귀";
                    default:
                        return "Rare";
                }
            case ItemGrade.EPIC:
                switch (language)
                {
                    case Language.KOREAN:
                        return "매우 희귀";
                    default:
                        return "Epic";
                }
            case ItemGrade.ANCIENT:
                switch (language)
                {
                    case Language.KOREAN:
                        return "고대";
                    default:
                        return "Ancient";
                }
            case ItemGrade.LEGEND:
                switch (language)
                {
                    case Language.KOREAN:
                        return "전설";
                    default:
                        return "Legend";
                }
            case ItemGrade.MYTHIC:
                switch (language)
                {
                    case Language.KOREAN:
                        return "신화";
                    default:
                        return "Mythic";
                }
            case ItemGrade.UNIQUE:
                switch (language)
                {
                    case Language.KOREAN:
                        return "유일";
                    default:
                        return "Unique";
                }
            default:
                switch (language)
                {
                    case Language.KOREAN:
                        return "이벤트";
                    default:
                        return "Event";
                }
        }
    }
}