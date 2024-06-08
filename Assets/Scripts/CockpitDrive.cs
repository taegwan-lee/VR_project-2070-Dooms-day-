using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitDrive : MonoBehaviour
{
    public Transform joystick;
    public float speed = 10f; // 이동 속도
    public float deadZoneAngle = 10f;
    public AudioSource movementSound; //부스터 소리
    public AudioSource movechange; //방향 바뀔 때 낼 소리

    private bool isMoving = false;

    void Update()
    {
        float xRotation = joystick.localEulerAngles.x;
        float zRotation = joystick.localEulerAngles.z;
        

        // 180까지만 받도록
        if (xRotation > 180) xRotation -= 360;
        if (zRotation > 180) zRotation -= 360;

        // 조이스틱이 deadZoneAngle 이내에 있으면 이동X
        if (Mathf.Abs(xRotation) < deadZoneAngle && Mathf.Abs(zRotation) < deadZoneAngle)
        {
            if (isMoving)
            {
                // 움직임이 멈추면 소리 정지
                movechange.Play();
                movementSound.Stop();
                isMoving = false;
            }
            return;
        }

        // 움직임이 발생하면 소리 재생
        if (!isMoving)
        {
            movechange.Play();
            movementSound.Play();
            isMoving = true;
        }

        Vector3 direction = new Vector3(-zRotation / 50, 0, xRotation / 45).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
