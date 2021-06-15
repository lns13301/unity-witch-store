using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleManager : MonoBehaviour
{
    private static float SALE_SPEED = 1.0f;

    public static SaleManager instance;

    public float saleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Initialize()
    {
        saleSpeed = SALE_SPEED;
    }
}