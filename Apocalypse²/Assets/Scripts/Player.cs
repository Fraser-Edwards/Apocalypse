using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float Health;
    public Slider HealthBar;

    public BloodSlashEffect bloodSlashEffect;

    private float previousHealth;
    private float accumulatedHealthDecrease;

    public float WinZombieAmount;
    public GameObject WinPanel;
    public GameObject LosePanel;

    public TextMeshProUGUI KillCount;

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        previousHealth = Health;

        HealthBar.maxValue = 100;
        HealthBar.minValue = 0;
        Health = 100;
        Time.timeScale = 1;
    }
    // private void Update()
    // {
    //     KillCount.text = WinZombieAmount.ToString();
    //     if(WinZombieAmount >= 20)
    //     {
    //         WinPanel.SetActive(true);
    //         Time.timeScale = 0;
    //     }
    // }
    public void TakeDamage(int damage)
    {
        previousHealth = Health;
        Health -= damage;

        float healthDecrease = previousHealth - Health;
        accumulatedHealthDecrease += healthDecrease;

        // Check if the accumulated health decrease is a multiple of 3
        if (accumulatedHealthDecrease >= 3)
        {
            bloodSlashEffect.ShowBloodSlash();
            accumulatedHealthDecrease -= 3;
        }

        if (Health <= 0)
        {
            Die();
        }
        HealthBar.value = Health;
    }

    private void Die()
    {
        // Implement death logic here
        Debug.Log("Player has died.");
        LosePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
