using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health References")]
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthBar;
    public float decreaseInterval = 1f;
    public float decreaseAmount = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.minValue = 0f;
        healthBar.maxValue = 1f;
        UpdateHealthBar();
    }

    public void GameStart() {
        StartCoroutine(DecreaseHealthRoutine());
    }

    IEnumerator DecreaseHealthRoutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            currentHealth -= decreaseAmount;
            if (currentHealth < 0)
                currentHealth = 0;

            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                GameOver();
                yield break;
            }
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }

    void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
