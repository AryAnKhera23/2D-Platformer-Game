using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverManager : MonoBehaviour
{
    [SerializeField] private LevelCompleteController completeController;
    [SerializeField] private KeyManager keyManager;
    LevelManager levelManager = LevelManager.Instance;

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            if(keyManager.isKeyCollected)
            {
                levelManager.MarkCurrentLevelComplete();
                completeController.LevelCompleted();
            }
            else
            {
                Debug.Log("Collect the Key to go to the next level");
            }
        }
    }

    

}
