using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
	public float minSpeed = 5f;
	public float maxSpeed = 15f;
	public float minRotationSpeed = 50f;
	public float maxRotationSpeed = 150f;
	public Vector3 direction = Vector3.forward;
	public float maxDistance = 100f; // 운석이 날아갈 최대 거리

	private float speed;
	private float rotationSpeed;
	private Vector3 startPosition;

	void Start()
	{
		speed = Random.Range(minSpeed, maxSpeed);
		rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
		startPosition = transform.position; // 시작 위치 저장
	}

	void Update()
	{
		// 설정된 방향으로 이동
		transform.Translate(direction * speed * Time.deltaTime, Space.World);
		// 회전
		transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

		// 이동한 거리를 체크하여 사라지게 함
		if (Vector3.Distance(startPosition, transform.position) > maxDistance)
		{
			Destroy(gameObject); // 일정 거리 이상 이동하면 오브젝트 파괴
		}
	}
}
