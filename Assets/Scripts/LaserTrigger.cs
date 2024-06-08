using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    private LaserAttack laserAttack; 
    private bool isActivating = false;

    void Start()
    {
        // LaserAttack 컴포넌트
        laserAttack = laserObject.GetComponent<LaserAttack>();
    }

    public void ActivateLaser()
    {
        if (!isActivating)
        {
            isActivating = true;
            laserObject.SetActive(true);
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
        isActivating = false; 
    }
}
