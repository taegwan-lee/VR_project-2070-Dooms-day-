using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJoystick : MonoBehaviour
{
    public Transform joystickTransform; // 조이스틱 오브젝트의 Transform 컴포넌트를 할당하기 위한 변수

    void Update()
    {
        if (joystickTransform != null)
        {
            // 조이스틱 오브젝트의 위치를 카메라 오브젝트의 위치와 동일하게 설정
            joystickTransform.position = transform.position;
        }
    }
}