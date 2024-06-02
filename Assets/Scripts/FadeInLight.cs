using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class FadeInLight : MonoBehaviour
{
    public Light targetLight; // 서서히 밝아질 Light 오브젝트
    public float fadeDuration = 2.0f; // 완전히 밝아지는데 걸리는 시간(초)
    public float maxIntensity = 1.0f; // Light의 최대 Intensity 값

    void Start()
    {
        // 초기 Intensity 값을 0으로 설정
        SetInitialIntensity();
    }

    void SetInitialIntensity()
    {
        targetLight.intensity = 0;
    }

    // 버튼 클릭 이벤트에 연결될 함수
    public void OnButtonClick()
    {
        StartCoroutine(FadeInLightIntensity());
    }

    IEnumerator FadeInLightIntensity()
    {
        float currentTime = 0.0f;
        float initialIntensity = targetLight.intensity;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float intensityValue = Mathf.Lerp(0, maxIntensity, currentTime / fadeDuration);
            targetLight.intensity = intensityValue;
            yield return null; // 다음 프레임까지 대기
        }

        // 최종적으로 Intensity 값을 maxIntensity로 설정
        targetLight.intensity = maxIntensity;
    }
}
