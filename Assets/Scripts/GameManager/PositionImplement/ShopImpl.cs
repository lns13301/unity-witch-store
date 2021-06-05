using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopImpl : PositionStrategy
{
    public PlayerPosition Initialize()
    {
        SoundInitialize();
        return PlayerPosition.SHOP;
    }

    public void SoundInitialize()
    {
        SoundManager.instance.StopAllSounds();
        SoundManager.instance.PlayMusicFindByName("Bird");
        SoundManager.instance.PlayMusicFindByName("Shop");
    }
}
