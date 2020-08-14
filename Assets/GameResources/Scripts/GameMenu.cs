using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private const float PAUSE_ACTIVE = 0f;
    private const float PAUSE_INACTIVE = 1f;
    
    public void ActivatePause(bool status)
    {
        Time.timeScale = status ? PAUSE_ACTIVE : PAUSE_INACTIVE;
    }

    public void BackToMenu(string menuScene)
    {
        SceneManager.LoadSceneAsync(menuScene);
    }

    private void OnDisable()
    {
        ActivatePause(false);
    }
}
