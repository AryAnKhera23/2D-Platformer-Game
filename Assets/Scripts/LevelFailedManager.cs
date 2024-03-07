using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedManager : MonoBehaviour
{
    [SerializeField] GameOverController controller;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out _))
        {
            Debug.Log("Game Over!! " + "Try Again.");
            controller.PlayerDead();
        }
    }
}
