using System;
using UnityEngine;
using UnityEngine.UI;

public class LimitedTimeOffer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private CanvasGroup canvasGroup;

    float timerInSeconds = 0;

    public void SetTimer(int timerInSeconds) 
    {
        this.timerInSeconds = timerInSeconds;
        canvasGroup.alpha = 1f;
    }

    private void Update()
    {
        if(timerInSeconds > 0) 
        {
            timerInSeconds -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timerInSeconds);
            timerText.text = time.ToString(@"hh\:mm\:ss");
        }
        else 
        {
            canvasGroup.alpha = 0f;
        }
    }
}
