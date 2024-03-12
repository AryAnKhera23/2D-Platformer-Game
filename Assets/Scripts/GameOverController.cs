using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button returnToMenuButton;
   

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
    }
    public void PlayerDead()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true); 
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ReturnToMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
