using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject objectToChangeTag;

    void OnTriggerEnter(Collider other)
    {
        // 보스의 태그를
        if (other.CompareTag("Player"))
        {
            // 파괴가능하도록 변경
            objectToChangeTag.tag = "Destroyable";
        }
    }
}
