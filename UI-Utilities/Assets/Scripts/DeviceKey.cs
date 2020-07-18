using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/UI/DeviceKey", fileName = "DeviceKey")]
public class DeviceKey : ScriptableObject
{
    public enum Key { DPad, DPadUp, DPadEast, DPadDown, DPadWest, ButtonNorth, ButtonEast, ButtonSouth, ButtonWest, LeftShoulder, LeftTrigger, RightShoulder, RightTrigger, Select, Start }
    public enum Device { PC, XBOX, PS4 }

    [Tooltip("Element:\n0 = PC\n1 = XBOX\n2 = PS4")]
    public List<Sprite> sprites;

    [Tooltip("To what Key the Sprites above correspond to?")]
    public Key key;
}
