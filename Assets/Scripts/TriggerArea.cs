using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TriggerArea : MonoBehaviour
{
    public GameObject objectToChangeTag;
    public AudioSource AlertSound;
    public GameObject AlertLight;
    public GameObject MeteorSpawn;

    void OnTriggerEnter(Collider other)
    {
        // 보스의 태그를
        if (other.CompareTag("Player"))
        {
            // 파괴가능하도록 변경
            AlertSound.Play();
            objectToChangeTag.tag = "Destroyable";
            StartCoroutine(BlinkLight()); 
            MeteorSpawn.SetActive(false);
        }
    }

    IEnumerator BlinkLight()
    {
        AlertLight.SetActive(true); // 라이트 오브젝트 활성화

        // 3초 동안 0.5초 간격으로 라이트를 깜빡이게 함
        Light lightToBlink = AlertLight.GetComponent<Light>();
        float endTime = Time.time + 3f;
        while (Time.time < endTime)
        {
            lightToBlink.enabled = !lightToBlink.enabled; // 라이트 상태 토글
            yield return new WaitForSeconds(0.5f); // 0.5초 대기
        }

        AlertLight.SetActive(false); // 최종적으로 라이트 오브젝트 비활성화
    }
}
