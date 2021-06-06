using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager instance;
    
    public List<GameObject> positionButtons;
    private PositionStrategy _registeredPositionStrategy;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePosition(PositionStrategy positionStrategy)
    {
        _registeredPositionStrategy?.CanvasDestroy();
        GameManager.instance.playerPosition = positionStrategy.Initialize();
        RegisterPosition(positionStrategy);
    }

    private void RegisterPosition(PositionStrategy positionStrategy)
    {
        _registeredPositionStrategy = positionStrategy;
    }
}
