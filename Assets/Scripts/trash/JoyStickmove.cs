using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoyStickmove : MonoBehaviour
{
    private Vector3 initialHandPosition;
    private Quaternion initialRotation;
    public Transform baseTransform; // 조이스틱이 고정될 기준점

    void Start()
    {
        initialRotation = transform.rotation;
    }

    public void OnGrab(XRBaseInteractor interactor)
    {
        initialHandPosition = interactor.transform.position;
    }

    public void OnRelease(XRBaseInteractor interactor)
    {
        transform.rotation = initialRotation; // 손을 놓으면 초기 회전으로 복귀
    }

    void Update()
    {
       
    }
}
