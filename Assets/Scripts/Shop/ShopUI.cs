using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;

    [SerializeField] private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panel = gameObject;

        SoundManager.instance.PlayMusicFindByName("Bird");
        SoundManager.instance.PlayMusicFindByName("Shop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOffPanel()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
