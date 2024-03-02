using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        menuSetActive();
    }

    public void menuSetActive()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        } 
    }
}
