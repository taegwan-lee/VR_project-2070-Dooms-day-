using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class FadeInLight : MonoBehaviour
{
    public Light targetLight; // 서서히 밝아질 Light 오브젝트
    public float fadeDuration = 2.0f; // 완전히 밝아지는데 걸리는 시간
    public float maxIntensity = 1.0f; // 최대 Intensity
    public LightBlink lightBlink; //시동 걸기전 깜빡거릴 불빛

    void Start()
    {
        //인턴시티 초기화
        SetInitialIntensity();
    }

    void SetInitialIntensity()
    {
        targetLight.intensity = 0;
    }

    //눌르면 실행될 함수
    public void OnButtonClick()
    {
        StartCoroutine(FadeInLightIntensity());
    }

    IEnumerator FadeInLightIntensity()
    {
        float currentTime = 0.0f;
        float initialIntensity = targetLight.intensity;
        lightBlink.StopBlinking();

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float intensityValue = Mathf.Lerp(0, maxIntensity, currentTime / fadeDuration);
            targetLight.intensity = intensityValue;
            yield return null; // 다음 프레임까지 대기
        }

        //Intensity 값을 maxIntensity까지 가게
        targetLight.intensity = maxIntensity;
    }
}
