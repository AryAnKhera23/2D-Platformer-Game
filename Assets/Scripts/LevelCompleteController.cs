using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    
    [SerializeField] private GameObject levelCompleteImage;
    [SerializeField] private Button loadNextLevel;
    [SerializeField] private Button returnToMenu;
    [SerializeField] private PlayerController playerController;
    LevelManager levelManager = LevelManager.Instance;

    private void Awake()
    {

        loadNextLevel.onClick.AddListener(LoadNextLevel);
        returnToMenu.onClick.AddListener(LoadMenu);
    }

    public void LevelCompleted()
    {
        levelCompleteImage.SetActive(true);
        playerController.enabled = false;
    }

    private void LoadMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = levelManager.GetNextSceneIndex();
        SoundManager.Instance.Play(Sounds.ButtonClick);
        if (nextSceneIndex < levelManager.Levels.Length)
        {
            levelManager.LoadLevel(levelManager.Levels[nextSceneIndex]);
        }
        
    }
}
