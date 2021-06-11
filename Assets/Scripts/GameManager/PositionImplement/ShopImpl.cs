using UnityEngine;

public class ShopImpl : PositionStrategy
{
    private static float UI_DEFAULT_RANGE = -800f;
    private static float UI_OUT_OF_RANGE = -4000f;

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
        Vector3 position = GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position;
        GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position = new Vector3(position.x, UI_OUT_OF_RANGE);
    }

    public void CanvasDestroy()
    {
        GameObject.Find("Background").transform.Find("Shop").gameObject.SetActive(false);
        
        Vector3 position = GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position;
        GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position = new Vector3(position.x, UI_DEFAULT_RANGE);
    }
}
