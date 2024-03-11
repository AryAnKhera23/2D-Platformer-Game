﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        [SerializeField] string LevelName;


        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);

            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Level is Locked!!");
                    break;

                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Completed:
                    SceneManager.LoadScene(LevelName);
                    break;
            }
            
        }
    }
    
}
