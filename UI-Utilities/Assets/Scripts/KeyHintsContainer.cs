using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Key
{
    [Tooltip("CommandTip Image that change dynamically")]
    public Image imageKey;
    [Tooltip("What Gamepad Button the Image corresponds to")]
    public DeviceKey.Key deviceKey;
}
public class KeyHintsContainer : MonoBehaviour
{
    InputHandler inputHandler;
    [Tooltip("How many CommandTips are in scene")]
    [SerializeField] List<Key> listKeys = new List<Key>();

    private void Start()
    {
        inputHandler = InputHandler.Instance;

        OnChangeDevice(inputHandler.currentController);
        inputHandler.OnChangeDevice += OnChangeDevice;
    }

    private void OnChangeDevice(DeviceKey.Device device)
    {
        foreach (Key key in listKeys)
        {
            if (key.imageKey != null) key.imageKey.sprite = inputHandler.GetKeyImage(device, key.deviceKey);
        }
    }
}
