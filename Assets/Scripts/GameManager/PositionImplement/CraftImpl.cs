using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftImpl : PositionStrategy
{
    public PlayerPosition Initialize()
    {
        SoundInitialize();
        return PlayerPosition.CRAFT;
    }
    
    public void SoundInitialize()
    {
        SoundManager.instance.StopAllSounds();
        SoundManager.instance.PlayMusicFindByName("Craft");
    }
}
