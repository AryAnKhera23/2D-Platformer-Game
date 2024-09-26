using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedManager : MonoBehaviour
{
    [SerializeField] GameOverController controller;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player))
        {
            Debug.Log("Game Over!! " + "Try Again.");
            if(player.healthManager.health > 0)
            {
                player.KillPlayer();
            }
            controller.PlayerDead();
        }
    }
}
