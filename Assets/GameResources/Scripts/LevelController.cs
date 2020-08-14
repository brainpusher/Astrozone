using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Timer timer;
    [SerializeField] private List<string> enemiesTags;
    
    private Coroutine waveRoutine;
    private bool isLevelActive;
    private Random random = new Random();

    private void OnEnable()
    {
        timer.OnTimerStart += SpawnWave;
        timer.OnTimerStop += StopSpawning;
    }

    private void OnDisable()
    {
        timer.OnTimerStart -= SpawnWave;
        timer.OnTimerStop -= StopSpawning;
    }

    private void StopSpawning()
    {
        if (waveRoutine != null)
        {
            StopCoroutine(waveRoutine);
            waveRoutine = null;
            isLevelActive = false;
        }
    }
    
    private void SpawnWave()
    {
        if (waveRoutine == null)
        {
            isLevelActive = true;
            waveRoutine = StartCoroutine(SpawnEnemiesRoutine());
        }
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (isLevelActive)
        {
            string randomEnemy = enemiesTags[random.Next(enemiesTags.Count)];
            int xMin = (int)(-cameraController.CameraHalfWidth);
            int xMax = (int)(cameraController.CameraHalfWidth);
            
            Vector3 spawnPosition = new Vector3(random.Next(xMin,xMax),0f,cameraController.CameraHalfHeight);
            
            yield return new WaitForSeconds(1f);
            
            objectPooler.SpawnFromPool(randomEnemy, spawnPosition, Quaternion.Euler(0f,180f,0f));
        }
    }
}
