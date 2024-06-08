using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string NextScene; 

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player")) 
        {
            Debug.Log("씬이 전환 되었음");
            SceneManager.LoadScene(NextScene); 
        }
    }
}
