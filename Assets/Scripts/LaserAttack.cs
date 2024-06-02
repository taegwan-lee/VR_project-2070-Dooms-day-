using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    public float appearDuration = 1.0f; // 나타나는 시간
    public float disappearDuration = 2.0f; // 사라지는 시간
    public Transform spawnPoint; // 레이저가 생성될 특정 오브젝트의 위치

    private MeshRenderer meshRenderer;
    private Material laserMaterial;
    private bool isActivating = false; // 현재 활성화 상태인지 확인
    private Vector3 originalScale;

    void Start()
    {
        meshRenderer = laserObject.GetComponent<MeshRenderer>();
        laserMaterial = meshRenderer.material;
        meshRenderer.enabled = false; // 초기에는 레이저가 보이지 않음
        originalScale = laserObject.transform.localScale; // 원래 크기 저장
    }

    void Update()
    {
      
    }

    public void ActivateLaser()
    {
        if (!isActivating)
        {
            StartCoroutine(ShowAndHideLaser());
        }
    }

    IEnumerator ShowAndHideLaser()
    {
        isActivating = true;

        meshRenderer.enabled = true;
        yield return new WaitForSeconds(appearDuration);

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

        meshRenderer.enabled = false;
        laserMaterial.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f);
        laserObject.transform.localScale = originalScale;

        isActivating = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // "Destroyable"는 파괴 가능한 오브젝트의 태그
        if (other.CompareTag("Destroyable"))
        {
            Destroy(other.gameObject); // 다른 오브젝트 파괴
        }
    }
}
