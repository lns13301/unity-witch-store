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
        GameObject.Find("SuperCanvas").transform.Find("CraftUI").gameObject.SetActive(true);
        LightManager.instance.SetGlobalLightIntensity(0.2f);
    }

    public void CanvasDestroy()
    {
        GameObject.Find("Background").transform.Find("Craft").gameObject.SetActive(false);
        GameObject.Find("SuperCanvas").transform.Find("CraftUI").gameObject.SetActive(false);
    }
}