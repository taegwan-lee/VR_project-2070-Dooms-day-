using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string NextScene; 

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 트리거에 들어오면 씬 전환
        if (other.CompareTag("Player")) // "Player" 태그를 사용하여 플레이어를 구별
        {
            Debug.Log("씬이 전환 되었음");
            SceneManager.LoadScene(NextScene); // 지정된 씬으로 전환
        }
    }
}
