using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public TextMeshProUGUI timerText;
    private bool _timerIsRunning = false; 
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
                DisplayTime(timeRemaining);
            }else{
                timeRemaining = 0;
                _timerIsRunning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            }
        }
        
        
    }
    private void DisplayTime(float time){
        float mins = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", mins, seconds);
    }
}
