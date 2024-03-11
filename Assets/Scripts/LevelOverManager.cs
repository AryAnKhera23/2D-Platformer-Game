using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverManager : MonoBehaviour
{
    [SerializeField] private KeyManager keyManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            if(keyManager.isKeyCollected)
            {
                LevelManager.Instance.MarkCurrentLevelComplete();
            }
            else
            {
                Debug.Log("Collect the Key to go to the next level");
            }
        }
    }
}
