using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void OnChangeDevice(DeviceKey.Device device);

public class InputHandler : Singleton<InputHandler>
{
    public DeviceKey.Device currentController;
    public InputDevice currentDevice;
    [HideInInspector] public List<DeviceKey> listKeys;

    public event OnChangeDevice OnChangeDevice;

    //public void SubscribeEventOnChangeDevice(OnChangeDevice onChangeDevice)
    //{
    //    OnChangeDevice += onChangeDevice;
    //}
    //public void DeSubscribeEventOnChangeDevice(OnChangeDevice onChangeDevice)
    //{
    //    OnChangeDevice -= onChangeDevice;
    //}

    private new void Awake()
    {
        base.Awake();
        listKeys = new List<DeviceKey>(Resources.LoadAll<DeviceKey>("Keys"));
        currentController = DeviceKey.Device.PC;
    }

    private void Start()
    {
        InputSystem.onActionChange += ChangeCurrentDevice;
    }
    private void ChangeCurrentDevice(object obj, InputActionChange actionChange)
    {
        if (actionChange == InputActionChange.ActionPerformed)
        {
            InputAction inputAction = (InputAction)obj;
            InputDevice device = inputAction.activeControl.device;

            //Check to avoid sending the same message too many times.
            if (device != currentDevice)
            {
                switch (device.name)
                {
                    case "XInputControllerWindows":
                        Debug.Log($"Current Device is {device.name}");
                        ChangeActiveController(DeviceKey.Device.XBOX, device);
                        break;

                    case "DualShock4GamepadHID":
                        Debug.Log($"Current Device is {device.name}");
                        ChangeActiveController(DeviceKey.Device.PS4, device);
                        break;

                    case "Keyboard":
                        Debug.Log($"Current Device is {device.name}");
                        ChangeActiveController(DeviceKey.Device.PC, device);
                        break;

                    case "Mouse":
                        Debug.Log($"Current Device is {device.name}");
                        ChangeActiveController(DeviceKey.Device.PC, device);
                        break;
                }
                OnChangeDevice?.Invoke(currentController);
                ChangeCursorStatus(currentController);
            }
        }
    }

    private void ChangeActiveController(DeviceKey.Device deviceKey, InputDevice newDevice)
    {
        currentController = deviceKey;
        currentDevice = newDevice;
    }
    private void ChangeCursorStatus(DeviceKey.Device currentDevice)
    {
        Cursor.visible = currentDevice == DeviceKey.Device.PC ? true : false;
    }

    public Sprite GetKeyImage(DeviceKey.Device device, DeviceKey.Key key)
    {
        foreach (DeviceKey k in listKeys)
        {
            if (key == k.key) return k.sprites[(int)device];
        }
        return null;
    }
}
