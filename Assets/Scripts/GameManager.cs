using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Language language;
    public PlayerPosition playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initialize()
    {
        language = Language.KOREAN;
        PositionManager.instance.InitializePosition(new ShopImpl());
    }
}
