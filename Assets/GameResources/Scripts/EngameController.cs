using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngameController : MonoBehaviour
{
    [SerializeField] private LifeController lifeController;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject looseWindow;
    [SerializeField] private GameMenu gameMenu;
    private void OnEnable()
    {
        lifeController.OnLivesSpent += DisplayLoose;
        timer.OnTimerStop += DispplayWin;
    }

    private void OnDisable()
    {
        lifeController.OnLivesSpent -= DisplayLoose;
        timer.OnTimerStop -= DispplayWin;
    }

    private void DisplayLoose()
    {
        looseWindow.SetActive(true);
        gameMenu.ActivatePause(true);
    }

    private void DispplayWin()
    {
        winWindow.SetActive(true);
        gameMenu.ActivatePause(true);
    }
    
}
