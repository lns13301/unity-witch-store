using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionButton : MonoBehaviour
{
    public void OnButton(int value)
    {
        SoundManager.instance.PlayOneShotEffectFindByName("BubblePop");
        PositionStrategy positionStrategy = FindPositionByIndex(value);
        PositionManager.instance.InitializePosition(positionStrategy);
    }

    private static PositionStrategy FindPositionByIndex(int value)
    {
        return value switch
        {
            0 => new ShopImpl(),
            1 => new ShopImpl(),
            2 => new CraftImpl(),
            3 => new ShopImpl(),
            _ => new ShopImpl()
        };
    }
}