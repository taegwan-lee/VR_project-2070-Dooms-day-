using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    public float appearDuration = 1.0f; // 나타나는 시간
    public float disappearDuration = 2.0f; // 사라지는 시간
    public Transform spawnPoint; 

    private MeshRenderer meshRenderer;
    private Material laserMaterial;
    private bool isActivating = false; // 현재 활성화 상태인지 확인
    private Vector3 originalScale;

    void Start()
    {
        meshRenderer = laserObject.GetComponent<MeshRenderer>();
        laserMaterial = meshRenderer.material;
        meshRenderer.enabled = false; // 초기에는 레이저가 보이지 않음
        originalScale = laserObject.transform.localScale; 
    }

    public void ActivateLaser()
    {
        if (!isActivating)
        {
            laserObject.transform.SetParent(spawnPoint, false);

            // 레이저 오브젝트 로컬 위치 회전 초기화
            laserObject.transform.localPosition = Vector3.zero;
            laserObject.transform.localRotation = Quaternion.identity;

            StartCoroutine(ShowAndHideLaser());
        }
    }

    IEnumerator ShowAndHideLaser()
    {
        isActivating = true;

        meshRenderer.enabled = true;
        laserMaterial.color = new Color(laserMaterial.color.r, laserMaterial.color.g, laserMaterial.color.b, 1.0f);
        yield return new WaitForSeconds(appearDuration);

        // 점차적으로 레이저를 사라지게 함
        float time = 0;
        Color initialColor = laserMaterial.color;
        while (time < disappearDuration)
        {
            float factor = Mathf.Lerp(1.0f, 0.0f, time / disappearDuration);
            laserMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, factor);
            laserObject.transform.localScale = new Vector3(originalScale.x * factor, originalScale.y, originalScale.z * factor);
            time += Time.deltaTime;
            yield return null;
        }

        meshRenderer.enabled = false; // 레이저를 완전히 숨김
        laserMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f); // 색상 초기화
        laserObject.transform.localScale = originalScale; // 크기 초기화

        isActivating = false;
    }
}