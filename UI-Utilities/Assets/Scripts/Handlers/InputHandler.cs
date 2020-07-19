using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public delegate void OnChangeDevice(DeviceKey.Device device);

public class InputHandler : Singleton<InputHandler>
{
    public DeviceKey.Device currentController;
    public InputDevice currentDevice;
    [HideInInspector] public Vector2 mousePosition;
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

    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
    }

    private void ChangeCurrentDevice(object obj, InputActionChange actionChange)
    {
        if (actionChange == InputActionChange.ActionPerformed)
        {
            InputAction inputAction = (InputAction)obj;
            InputDevice newDevice = inputAction.activeControl.device;

            // Check if the new Device detected is different from the last used Device.
            if (newDevice != currentDevice)
            {
                switch (newDevice.name)
                {
                    case "XInputControllerWindows":
                        ChangeActiveController(DeviceKey.Device.XBOX, newDevice);
                        break;

                    case "DualShock4GamepadHID":
                        ChangeActiveController(DeviceKey.Device.PS4, newDevice);
                        break;

                    case "Keyboard":
                        ChangeActiveController(DeviceKey.Device.PC, newDevice);
                        break;

                    case "Mouse":
                        ChangeActiveController(DeviceKey.Device.PC, newDevice);
                        break;
                }
                //Debug.Log($"Current Device is {device.name}");
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
