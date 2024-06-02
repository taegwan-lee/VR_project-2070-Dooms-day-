using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitMove : MonoBehaviour
{
    public Transform joystick; // 조이스틱 오브젝트의 Transform
    public float speed = 1.0f; // 이동 속도 조절을 위한 변수

    void Update()
    {
        // 조이스틱의 Z축 회전 값
        float rotationX = joystick.eulerAngles.x;

        if (rotationX > 180)
        {
            rotationX -= 360;
        }

        // -40에서 40도 사이의 회전 값에 따라 오브젝트를 앞뒤로 이동시킵니다.
        // rotationX 값이 음수이면 오브젝트를 뒤로, 양수이면 앞으로 이동시킵니다.
        Vector3 moveDirection = new Vector3(0, 0, rotationX / 40); // -1에서 1 사이의 값을 얻기 위해 40으로 나눕니다.
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

}
