using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    private LaserAttack laserAttack; // LaserAttack 스크립트에 대한 참조
    private bool isActivating = false; // 현재 활성화 상태인지 확인

    void Start()
    {
        // LaserAttack 컴포넌트를 찾아 저장합니다.
        laserAttack = laserObject.GetComponent<LaserAttack>();
    }

    public void ActivateLaser()
    {
        if (!isActivating)
        {
            isActivating = true;
            laserObject.SetActive(true);
            // LaserAttack 스크립트의 ActivateLaser 함수를 호출합니다.
            if (laserAttack != null)
            {
                laserAttack.ActivateLaser();
            }
            StartCoroutine(DeactivateLaserAfterSeconds(3));
        }
    }

    IEnumerator DeactivateLaserAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds); // 지정된 시간만큼 대기
        laserObject.SetActive(false); // 레이저 비활성화
        isActivating = false; // 활성화 상태를 false로 설정
    }
}
