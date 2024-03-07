using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
