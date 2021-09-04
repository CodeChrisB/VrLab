using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XrInput
{

    private InputActionAsset set;
    public XrInput(InputActionAsset set){this.set = set;}
    public InputAction GetInput(XrEnum xrEnum)
    {
        return set.FindActionMap(GetDeviceString((int)xrEnum)).FindAction(GetInputString((int)xrEnum));
    }
    private string GetDeviceString(int value)
    {
        if (value < 13) return "XRI LeftHand"; //0-12 left
        if (value < 26) return "XRI RightHand"; //13-25 right
        return "XRI HMD"; //26-27 head
    }
    private string GetInputString(int value) 
    {
        switch (value)
        {
            case 0:
            case 13:
            case 26:
                return "Position";
            case 1:
            case 14:
            case 27:
                return "Rotation";
            case 2:
            case 15:
                return "Select";
            case 3:
            case 16:
                return "Activate";
            case 4:
            case 17:
                return "UI Press";
            case 5:
            case 18:
                return "Haptic Device";
            case 6:
            case 19:
                return "Teleport Mode Select";
            case 7:
            case 20:
                return "Teleport Mode Activate";
            case 8:
            case 21:
                return "Teleport Mode Cancel";
            case 9:
            case 22:
                return "Turn";
            case 10:
            case 23:
                return "Move";
            case 11:
            case 24:
                return "Rotate Anchor";
            case 12:
            case 25:
                return "Translate Anchor";
            default:
                return "";
        }
        
    }
}
