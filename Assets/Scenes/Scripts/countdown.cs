using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    public int minutes = 2;
    public int seconds = 00;
    public Text timerText;
    public Image timerFillImage;
    public GameObject gameOverPanel;

    private float totalTimeInSeconds;
    private float timeLeft;

    public event Action TimerEnded;

    private void Start()
    {
        totalTimeInSeconds = minutes * 60 + seconds;
        timeLeft = totalTimeInSeconds;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
            UpdateFillImage();

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                TimerEnded?.Invoke();
                ShowGameOverPanel();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timerText.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
    }

    private void UpdateFillImage()
    {
        float fillAmount = timeLeft / totalTimeInSeconds;
        timerFillImage.fillAmount = fillAmount;
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void ResetTimer()
    {
        timeLeft = totalTimeInSeconds;
        UpdateTimerDisplay();
        UpdateFillImage();
    }
    public void restartButton()
    {
        SceneManager.LoadScene("Carrom Scene");
    }
    public void mainmenuButton()
    {
        SceneManager.LoadScene("Intro");
    }
}


