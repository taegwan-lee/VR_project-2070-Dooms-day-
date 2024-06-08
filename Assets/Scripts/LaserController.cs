using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class LaserController : MonoBehaviour
{
    public GameObject laserObject; // 레이저 오브젝트
    public float appearDuration = 1.0f; // 나타나는 시간
    public float disappearDuration = 2.0f; // 사라지는 시간
    public Transform spawnPoint; 
    public float deactivationDelay = 3.0f; // 쿨

    public AudioClip laserSound; //공격 소리
    private AudioSource audioSource; 

    private MeshRenderer meshRenderer;
    private Material laserMaterial;
    private bool isActivating = false; // 현재 활성화 상태인지 확인
    private Vector3 originalScale;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //공격소리 가져오기
        audioSource.clip = laserSound;

        meshRenderer = laserObject.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            laserMaterial = meshRenderer.material;
            originalScale = laserObject.transform.localScale; // 원래 크기 저장
            meshRenderer.enabled = false; // 초기에는 레이저가 보이지 않음
        }
        else
        {
            Debug.LogError("Laser object does not have a MeshRenderer component.");
        }
    }

    public void ActivateLaser()
    {
        if (!isActivating)
        {
            laserObject.SetActive(true);

            audioSource.time = 0.3f;
            audioSource.Play();

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

        yield return new WaitForSeconds(deactivationDelay - disappearDuration);
        meshRenderer.enabled = false;
        laserMaterial.color = initialColor;
        laserObject.transform.localScale = originalScale;
        laserObject.SetActive(false);
        isActivating = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Destroyable"))
        {
            Destroy(other.gameObject); 
        }
    }
}
