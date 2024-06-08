using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJoystick : MonoBehaviour
{
    public Transform joystickTransform; 

    void Update()
    {
        if (joystickTransform != null)
        {
            joystickTransform.position = transform.position;
        }
    }
}