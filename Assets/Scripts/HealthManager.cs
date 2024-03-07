using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHearts;
    [SerializeField] private Sprite emptyHearts;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = emptyHearts;
        }

        
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHearts;
        }
    }
}
