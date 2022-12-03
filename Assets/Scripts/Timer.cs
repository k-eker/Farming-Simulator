using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private int m_StartingTime;
    private int m_RemainingTime;
    private Vector3 m_Position;
    public float CompletionValue
    {
        get
        {
            int passedTime = m_StartingTime - m_RemainingTime;
            float completionValue = (float)passedTime / (float)m_StartingTime;
            return completionValue;
        }
    }

    public Timer(int seconds, Vector3 position, MonoBehaviour mono, Action<Timer> onTick = null, Action onComplete = null)
    {
        m_StartingTime = seconds;
        m_Position = position;
        mono.StartCoroutine(TimerCoroutine(onTick, onComplete));
    }


    IEnumerator TimerCoroutine(Action<Timer> onTick, Action onComplete)
    {
        m_RemainingTime = m_StartingTime;
        WaitForSeconds oneSecond = new WaitForSeconds(1);
        FloatingText floatingText = GameManager.Instance.uiController.CreateFloatingText(m_Position, m_StartingTime);

        while (m_RemainingTime > 0)
        {
            floatingText.SetText(FormatTime(m_RemainingTime));

            yield return oneSecond;
            m_RemainingTime--;
            onTick?.Invoke(this);
        }

        floatingText.SetText(FormatTime(m_RemainingTime));

        onComplete?.Invoke();
    }

    private string FormatTime(int remainingTime)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);

        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
