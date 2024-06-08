using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
	public GameObject meteorPrefab;
	public float spawnInterval = 2f;
	public Vector3 spawnPosition;
	public float randomRange = 1000f; // 좌우 범위

	private void Start()
	{
		InvokeRepeating("SpawnMeteor", 0f, spawnInterval);
	}

	void SpawnMeteor()
	{
		Vector3 randomOffset = new Vector3(Random.Range(-randomRange, randomRange), 0f, 0f);
		Vector3 spawnPos = spawnPosition + randomOffset;

		GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
		meteor.SetActive(true); // 운석 활성화

		// 운석의 이동 방향
		Meteor meteorScript = meteor.GetComponent<Meteor>();
		meteorScript.direction = Vector3.back; // 정면으로 이동
	}
}


