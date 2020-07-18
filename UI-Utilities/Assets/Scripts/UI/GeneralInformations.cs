using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralInformations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCurrentDevice = null;
    InputHandler inputHandler;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
        OnChangeDeviceText(inputHandler.currentController);
        inputHandler.OnChangeDevice += OnChangeDeviceText;
    }

    private void OnChangeDeviceText(DeviceKey.Device device)
    {
        textCurrentDevice.text = $"Current device is of type {device}";
    }

}
