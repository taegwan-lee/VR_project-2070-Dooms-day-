using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FadeInRenderer : MonoBehaviour
{
    public Renderer[] targetRenderers; // 서서히 나타나게 할 오브젝트의 Renderer 배열
    public Light[] targetLights; // 서서히 밝아질 Light 오브젝트 배열
    public float fadeDuration = 2.0f; // 완전히 나타나거나 밝아지는데 걸리는 시간(초)
    public AudioSource BootingSound; // 부팅 소리
    public LightBlink lightBlink; // 시동 걸기 전 깜빡거리는 불빛

    void Start()
    {
        // 초기 Alpha 값을 모든 렌더러에 대해 0으로 설정
        foreach (Renderer renderer in targetRenderers)
        {
            Color initialColor = renderer.material.color;
            initialColor.a = 0;
            renderer.material.color = initialColor;
        }

        // 초기 Intensity 값을 모든 라이트에 대해 0으로 설정
        foreach (Light light in targetLights)
        {
            light.intensity = 0;
        }
    }

    // 버튼 클릭 이벤트에 연결될 함수
    public void OnButtonClick()
    {
        StartCoroutine(FadeInObjectsAndLights());
    }

    IEnumerator FadeInObjectsAndLights()
    {
        float currentTime = 0.0f;
        BootingSound.Play();
        lightBlink.StopBlinking();

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            float intensityValue = Mathf.Lerp(0, 1, currentTime / fadeDuration); // 가정: 라이트의 최대 Intensity가 1이라고 가정

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

            yield return null; // 다음 프레임까지 대기
        }

        // 최종적으로 모든 렌더러의 Alpha 값을 1로 설정
        foreach (Renderer renderer in targetRenderers)
        {
            Color targetColor = renderer.material.color;
            targetColor.a = 1.0f;
            renderer.material.color = targetColor;
        }

        // 최종적으로 모든 라이트의 Intensity 값을 1로 설정 (또는 원하는 최대값으로 설정 가능)
        foreach (Light light in targetLights)
        {
            light.intensity = 1.0f; // 또는 원하는 최대값으로 설정
        }
    }
}