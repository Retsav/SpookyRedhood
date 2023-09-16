using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject lampLight;
    private bool lightState = true;

    private void Start()
    {
        gameInput.OnLampStateChanged += GameInputOnOnLampStateChanged;
    }

    private void GameInputOnOnLampStateChanged(object sender, EventArgs e)
    {
        lightState = !lightState;
        lampLight.GetComponent<Light>().enabled = lightState;
    }
}
