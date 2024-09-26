using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(QuitApplication);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitApplication()
    {
        Application.Quit();
    }
}
