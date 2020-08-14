using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float> OnChangeTime = delegate {  };
    public event Action OnTimerStart = delegate { };
    public event Action OnTimerStop = delegate {  };
    
    [SerializeField] private float secondsToCount = 50f;
    [SerializeField] private float tickTime = 1f;
    [SerializeField] private bool isCountUp = false;
    
    private Coroutine timerRoutine;

    private void OnEnable()
    {
        StartTimer();
    }

    private void OnDisable()
    {
        StopTimer();
    }

    private void StartTimer()
    {
        if (timerRoutine == null)
        {
            timerRoutine = StartCoroutine(isCountUp ? CountUp() : CountDown());
            OnTimerStart?.Invoke();
        }
    }

    private void StopTimer()
    {
        if (timerRoutine != null)
        {
            StopCoroutine(timerRoutine);
            timerRoutine = null;
        }
    }

    public void RestartTimer()
    {
        StopTimer();
        StartTimer();
    }

    private IEnumerator CountUp()
    {
        float count = 0f;
        while (count < secondsToCount)
        {
            yield return new WaitForSeconds(tickTime);
            count++;
            OnChangeTime?.Invoke(count);
        }
        OnTimerStop?.Invoke();
    }

    private IEnumerator CountDown()
    {
        float count = secondsToCount;
        while (count > 0f)
        {
            yield return new WaitForSeconds(tickTime);
            count--;
            OnChangeTime?.Invoke(count);
        }
        OnTimerStop?.Invoke();
    }
    
}
