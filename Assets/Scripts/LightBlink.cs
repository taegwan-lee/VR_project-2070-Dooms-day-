using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    public Light pointLight; // ±ôºýÀÌ°Ô ÇÒ Light ÄÄÆ÷³ÍÆ®
    public float blinkInterval = 0.5f; // ±ôºýÀÌ´Â °£°Ý (ÃÊ)
    private bool isBlinking = true;

    void Start()
    {
        if (pointLight == null)
        {
            pointLight = GetComponent<Light>();
        }

        StartCoroutine(BlinkLight());
    }

    IEnumerator BlinkLight()
    {
        while (isBlinking)
        {
            pointLight.intensity = pointLight.intensity == 0 ? 2 : 0;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        isBlinking = false;
        pointLight.enabled = false;
    }
}
