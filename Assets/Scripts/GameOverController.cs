﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button returnToMenuButton;
    [SerializeField] PlayerController playerController;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
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

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
