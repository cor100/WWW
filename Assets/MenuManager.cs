using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menuSetActive();
    }
    public void menuSetActive(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("esc");
            menu.SetActive(!menu.activeSelf);
        } 
    }
}
