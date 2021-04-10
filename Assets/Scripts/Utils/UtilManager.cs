using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilManager : MonoBehaviour
{
    public static UtilManager instance;

    public RandomGenerator randomGenerator = new RandomGenerator();
    public NumberFormatter numberFormatter = new NumberFormatter();
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
