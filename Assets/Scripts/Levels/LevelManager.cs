using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    [SerializeField] string[] Level;

    private void Awake()
    {
        //Singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus(Level[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Level[0], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    internal void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = Array.FindIndex(Level, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        Debug.Log(Level[currentSceneIndex] + " Complete!!");
        SetLevelStatus(Level[currentSceneIndex], LevelStatus.Completed);

        if (nextSceneIndex < Level.Length)
        {
            SetLevelStatus(Level[nextSceneIndex], LevelStatus.Unlocked);
            SceneManager.LoadScene(Level[nextSceneIndex]);
        }

        
    }
}
