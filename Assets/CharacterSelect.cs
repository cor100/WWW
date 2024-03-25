using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] chars;
    public int selectedCharacter = 0;

    public void NextCharacter(){
        chars[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % chars.Length;
        chars[selectedCharacter].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
