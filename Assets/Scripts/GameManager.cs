using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerData playerData;

    public PlayerData PlayerData
    {
        get => playerData;
        set => playerData = value;
    }

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
        playerData = new PlayerData.Builder("test@test.com", "test123")
            .Language(Language.KOREAN)
            .PlayerPosition(PlayerPosition.SHOP)
            .Money(1000L)
            .Cash(100)
            .build();
        playerData.language = playerData.language;
        PositionManager.instance.InitializePosition(playerData.playerPosition);
        UIManager.instance.UpdateMoney(playerData.money);
    }
}
