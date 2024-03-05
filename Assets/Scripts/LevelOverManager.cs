using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            Debug.Log("Level Over!!");
            SceneManager.LoadScene(0);
        }
    }
}
