using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    [SerializeField] private Timer timer;


    // Update is called once per frame
    void Update()
    {
        menuSetActive();
        if(menu.activeSelf){
            timer.pauseTimer();
        }else{
            timer.resumeTimer();
        }
    }

    public void menuSetActive()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        } 
    }
}
