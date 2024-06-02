using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FadeInRenderer : MonoBehaviour
{
    public Renderer targetRenderer; // 서서히 나타나게 할 오브젝트의 Renderer
    public float fadeDuration = 2.0f; // 완전히 나타나는데 걸리는 시간(초)

    void Start()
    {
        // 초기 Alpha 값을 0으로 설정
        SetInitialAlpha();
    }

    void SetInitialAlpha()
    {
        Color initialColor = targetRenderer.material.color;
        initialColor.a = 0;
        targetRenderer.material.color = initialColor;
    }

    // 버튼 클릭 이벤트에 연결될 함수
    public void OnButtonClick()
    {
        StartCoroutine(FadeInObject());
    }

    IEnumerator FadeInObject()
    {
        float currentTime = 0.0f;
        Color initialColor = targetRenderer.material.color;
        Color targetColor = initialColor;
        targetColor.a = 1.0f;

        // 초기 Alpha 값을 0으로 설정 (중복 설정이므로 필요 없을 수 있음)
        initialColor.a = 0;
        targetRenderer.material.color = initialColor;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            Color newColor = initialColor;
            newColor.a = alphaValue;
            targetRenderer.material.color = newColor;
            yield return null; // 다음 프레임까지 대기
        }

        // 최종적으로 Alpha 값을 1로 설정
        targetColor.a = 1.0f;
        targetRenderer.material.color = targetColor;
    }
}
