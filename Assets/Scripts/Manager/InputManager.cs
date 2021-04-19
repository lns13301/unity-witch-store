using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private static string DEFAULT_FIELD = "";

    public static InputManager instance;
    
    public Text inputFieldText;
    [SerializeField] private TouchScreenKeyboard _keyboard;
    public Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKeyboard();
    }

    public void OpenKeyboard()
    {
        _keyboard = TouchScreenKeyboard.Open(DEFAULT_FIELD);
    }

    private void UpdateKeyboard()
    {
        if (!TouchScreenKeyboard.visible && _keyboard != null)
        {
            if (_keyboard.done || Input.GetKeyUp(KeyCode.Return))
            {
                targetText.text = inputFieldText.text;
                _keyboard = null;
            }
        }
    }
}
