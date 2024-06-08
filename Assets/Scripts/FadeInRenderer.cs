using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FadeInRenderer : MonoBehaviour
{
    public Renderer[] targetRenderers; // 계기판용 렌더러
    public Light[] targetLights; 
    public float fadeDuration = 2.0f; //밝아지는데 걸릴 시간
    public AudioSource BootingSound; // 시동 거는 소리
    public LightBlink lightBlink; 

    public GameObject MeteorSpawn;

    void Start()
    {
        
        foreach (Renderer renderer in targetRenderers)
        {
            Color initialColor = renderer.material.color;
            initialColor.a = 0;
            renderer.material.color = initialColor;
        }

        
        foreach (Light light in targetLights)
        {
            light.intensity = 0;
        }
    }

 
    public void OnButtonClick()
    {
        StartCoroutine(FadeInObjectsAndLights());
    }

    IEnumerator FadeInObjectsAndLights()
    {
        float currentTime = 0.0f;
        BootingSound.Play();
        lightBlink.StopBlinking();
        MeteorSpawn.SetActive(true);

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            float intensityValue = Mathf.Lerp(0, 1, currentTime / fadeDuration); 

            foreach (Renderer renderer in targetRenderers)
            {
                Color newColor = renderer.material.color;
                newColor.a = alphaValue;
                renderer.material.color = newColor;
            }

            foreach (Light light in targetLights)
            {
                light.intensity = intensityValue;
            }

            yield return null; 
        }

        // 최종적으로 모든 렌더러의 Alpha 값을 1로 설정
        foreach (Renderer renderer in targetRenderers)
        {
            Color targetColor = renderer.material.color;
            targetColor.a = 1.0f;
            renderer.material.color = targetColor;
        }

        // 최종적으로 모든 라이트의 Intensity 값을 1로 설정
        foreach (Light light in targetLights)
        {
            light.intensity = 1.0f; 
        }
    }
}