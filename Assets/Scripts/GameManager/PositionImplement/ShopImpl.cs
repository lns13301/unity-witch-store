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
        SoundManager.instance.PlayVoiceFindByName("ShopVoice");
    }

    public void CanvasInitialize()
    {
        GameObject.Find("Background").transform.Find("Shop").gameObject.SetActive(true);
        LightManager.instance.SetGlobalLightIntensity(0.7f);
        GameObject.Find("Canvas").transform.Find("PlayerShopUI").gameObject.SetActive(true);

        //Vector3 position = GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position;
        //GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().localPosition = new Vector2(position.x, UI_DEFAULT_RANGE);
    }

    public void CanvasDestroy()
    {
        GameObject.Find("Background").transform.Find("Shop").gameObject.SetActive(false);
        //GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<ShopUI>().OffPanel();
        GameObject.Find("Canvas").transform.Find("PlayerShopUI").gameObject.SetActive(false);

        //Vector3 position = GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().position;
        //GameObject.Find("Canvas").transform.Find("PlayerShopUI").GetComponent<RectTransform>().localPosition = new Vector2(position.x, UI_OUT_OF_RANGE);
    }
}