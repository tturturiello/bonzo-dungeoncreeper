using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput
{
    public static bool IsOnActionPressed() => Input.GetKey(KeyCode.E);

    public static bool IsOnObjectActionPressed() => Input.GetKey(KeyCode.Q);

    public static bool HasRotatedObject() => Input.GetKeyDown(KeyCode.R);

    public static bool IsOnBuildActionPressed() => Input.GetMouseButton(0);

    public static bool IsOnCrouchedPressed() => Input.GetKey(KeyCode.LeftControl)
        || Input.GetKey(KeyCode.RightControl);

    public static bool HasSwitchedCamera() => Input.GetKeyUp(KeyCode.F);

    public static bool IsOnDropActionPressed() => IsOnDropActionPressed(0) 
        || IsOnDropActionPressed(1) 
        || IsOnDropActionPressed(2);

    public static bool IsOnDropActionPressed(int index)
    {
        switch(index)
        {
            case 0: return Input.GetKey(KeyCode.Alpha1);
            case 1: return Input.GetKey(KeyCode.Alpha2);
            case 2: return Input.GetKey(KeyCode.Alpha3);
            default: return false;
        }
    }

}
