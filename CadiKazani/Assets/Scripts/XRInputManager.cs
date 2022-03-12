using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A utility class that handles Inputs for both VR and Desktop controls.
/// </summary>
public static class XRInputManager
{
    /// <summary>
    /// Method to allow button controls for both Desktop and VR. Returns if the
    /// button input for either is pressed.
    /// </summary>
    /// <returns>If the button for either VR or Desktop controls was pressed down this frame.</returns>
    public static bool IsButtonDown()
    {
        return Input.GetMouseButtonDown(0) || Google.XR.Cardboard.Api.IsTriggerPressed;
    }
}
