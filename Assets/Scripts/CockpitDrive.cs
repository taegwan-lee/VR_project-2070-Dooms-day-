using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitDrive : MonoBehaviour
{
    public Transform joystick; 
    public float speed = 10f; // 이동 속도
    public float deadZoneAngle = 10f;

    void Update()
    {
        float xRotation = joystick.localEulerAngles.x;
        float zRotation = joystick.localEulerAngles.z;

        //180을 초과하는 값은 음수로 변환
        if (xRotation > 180) xRotation -= 360;
        if (zRotation > 180) zRotation -= 360;

        // 조이스틱이 deadZoneAngle 이내에 있으면 이동X
        if (Mathf.Abs(xRotation) < deadZoneAngle && Mathf.Abs(zRotation) < deadZoneAngle)
        {
            return; 
        }

 
        Vector3 direction = new Vector3(-zRotation / 50, 0, xRotation / 45).normalized;


        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
