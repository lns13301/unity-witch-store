using UnityEngine;

public class ShopImpl : PositionStrategy
{
    public PlayerPosition Initialize()
    {
        SoundInitialize();
        CanvasInitialize();
        return PlayerPosition.SHOP;
    }

    public void SoundInitialize()
    {
        SoundManager.instance.StopAllSounds();
        SoundManager.instance.PlayMusicFindByName("Bird");
        SoundManager.instance.PlayMusicFindByName("Shop");
    }

    public void CanvasInitialize()
    {
        GameObject.Find("Background").transform.Find("Shop").gameObject.SetActive(true);
    }

    public void CanvasDestroy()
    {
        GameObject.Find("Background").transform.Find("Shop").gameObject.SetActive(false);
    }
}
