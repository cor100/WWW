using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool isLoadedUI = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject menu = GameObject.Find("MenuObject");
        // Make the GameObject persist across scene changes
        if(menu && isLoadedUI)
        {
            DontDestroyOnLoad(menu);
            isLoadedUI = true;
        }
    }
}
