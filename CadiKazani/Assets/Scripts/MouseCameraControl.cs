using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraControl : MonoBehaviour
{
    public Vector2 rotationSpeed;

    void Start()
    {
        // To match the mouse movement, the y rotation speed should be inverted
        rotationSpeed = new Vector2(rotationSpeed.x, -1 * rotationSpeed.y);
    }

    void Update()
    {
        // If right mouse-button pressed
        if (Input.GetMouseButton(1))
        {
            var horizontalRotation = rotationSpeed.x * new Vector3(0, Input.GetAxis("Mouse X"), 0);
            var verticalRotation = rotationSpeed.y * new Vector3(Input.GetAxis("Mouse Y"), 0, 0);

            transform.Rotate(horizontalRotation, Space.World); // Rotate around world y-axis
            transform.Rotate(verticalRotation, Space.Self); // Rotate around camera's x-axis
        }
    }
}
