using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    //[SerializeField] private Transform target;
    [SerializeField] private Transform parentTransform; // Reference transform for scaling

    private Vector3 initialScale;

    private void Start()
    {
        // Store the initial scale of the health bar
        initialScale = transform.localScale;
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health/maxHealth;
    }

    private void Update()
    {
        float enemyScaleSignX = Mathf.Sign(parentTransform.localScale.x);

        // Set the health bar's local scale to match the sign of the enemy's local scale in the x-axis
        Vector3 adjustedScale = new Vector3(initialScale.x * enemyScaleSignX, initialScale.y, initialScale.z);
        transform.localScale = adjustedScale;
    }

}
