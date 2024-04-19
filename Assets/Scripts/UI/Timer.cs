using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public TextMeshProUGUI timerText;
    private bool _timerIsRunning = false;
    private bool _hasNotStartFade = true;

    // Start is called before the first frame update
    void Start()
    {
        _timerIsRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(_timerIsRunning){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                Console.WriteLine(timeRemaining);
                DisplayTime(timeRemaining);
            }else{
                timeRemaining = 0;
                _timerIsRunning = false;
                _hasNotStartFade = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            }

            // This changes background at 20 second mark
            if (_hasNotStartFade && timeRemaining <= 20)
            {
                BackgroundChange.Instance.StartFade();
                _hasNotStartFade = false;
            }

            // This sets off shaking at the 5 second timer
            if (timeRemaining <= 5)
            {
                CameraShake.Instance.ShakeCamera(.4f, .5f);
            }

        } 
    }

    private void DisplayTime(float time)
    {
        float mins = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", mins, seconds);
    }

    public float getTime()
    {
        return timeRemaining;
    }
}
