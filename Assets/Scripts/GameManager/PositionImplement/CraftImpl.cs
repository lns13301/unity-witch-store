using UnityEngine;

public class CraftImpl : PositionStrategy
{
    public PlayerPosition Initialize()
    {
        SoundInitialize();
        CanvasInitialize();
        return PlayerPosition.CRAFT;
    }
    
    public void SoundInitialize()
    {
        SoundManager.instance.StopAllSounds(true);
        SoundManager.instance.PlayMusicFindByName("Craft");
    }

    public void CanvasInitialize()
    {
        GameObject.Find("Background").transform.Find("Craft").gameObject.SetActive(true);
    }

    public void CanvasDestroy()
    {
        GameObject.Find("Background").transform.Find("Craft").gameObject.SetActive(false);
    }
}
