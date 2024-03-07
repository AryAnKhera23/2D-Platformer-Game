using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    [SerializeField] PlayerController playerController;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        quitButton.onClick.AddListener(ApplicationQuit);
    }
    public void PlayerDead()
    {
        gameObject.SetActive(true);
        playerController.enabled = false;
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ApplicationQuit()
    {
        Application.Quit();
    }
}
