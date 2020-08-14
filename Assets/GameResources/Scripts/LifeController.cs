using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    private const int LIVES_COUNT = 3;
    
    public event Action OnLivesSpent = delegate {  };
    
    [SerializeField] private TriggerManager playerTriggerManager;
    [SerializeField] private List<GameObject> liveImages;

    private int lifeCount = LIVES_COUNT;

    private void OnEnable()
    {
        playerTriggerManager.OnPlayerDead += SpendLife;
    }

    private void OnDisable()
    {
        playerTriggerManager.OnPlayerDead -= SpendLife;
    }

    private void SpendLife()
    {
        if (lifeCount > 0)
        {
            lifeCount--;
            liveImages[lifeCount].SetActive(false);
            playerTriggerManager.gameObject.SetActive(true);
        }
        else
        {
            OnLivesSpent.Invoke();
        }
    }

    public void ResetLives()
    {
        lifeCount = LIVES_COUNT;
        foreach (GameObject life in liveImages)
        {
            life.SetActive(true);
        }
        playerTriggerManager.gameObject.SetActive(true);
    }
    
}
