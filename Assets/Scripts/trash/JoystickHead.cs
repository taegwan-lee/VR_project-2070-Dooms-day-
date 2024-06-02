using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickHead : MonoBehaviour
{
    public Transform airplane; // 비행기 오브젝트를 지정할 변수입니다.
    private Vector3 initialPosition; // 조이스틱 헤드의 초기 위치입니다.

    void Start()
    {
        initialPosition = transform.position; // 초기 위치를 저장합니다.
    }

    void Update()
    {
        Vector3 direction = transform.position - initialPosition; // 현재 위치와 초기 위치의 차이를 이용하여 방향을 구합니다.

        if (direction.magnitude > 0.1f) // 조이스틱이 충분히 움직였는지 확인합니다. (0.1f는 조이스틱 민감도에 따라 조정할 수 있습니다.)
        {
            direction = direction.normalized; // 방향 벡터를 정규화합니다.
            airplane.Translate(direction * Time.deltaTime, Space.World); // 비행기를 움직입니다.
        }
        else
        {
            // 조이스틱 움직임이 없을 때 비행기를 멈추게 할 수 있습니다.
            // 예를 들어, 여기에 비행기 속도를 점차 줄이는 로직을 추가할 수 있습니다.
        }
    }
}
