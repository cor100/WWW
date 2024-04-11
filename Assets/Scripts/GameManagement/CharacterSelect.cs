using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int selectedCharacter = 0;

    [SerializeField] private GameObject[] chars;
    [SerializeField] private GameObject[] stats;
    [SerializeField] TMP_Text charLabel;
    private string[] prefabNames = {"Owl", "Blue", "Pink"};



    public void NextCharacter(){
        chars[selectedCharacter].SetActive(false);
        stats[selectedCharacter].SetActive(false);

        selectedCharacter = (selectedCharacter + 1) % chars.Length;
        chars[selectedCharacter].SetActive(true);
        stats[selectedCharacter].SetActive(true);

        charLabel.text = prefabNames[selectedCharacter];
        print(selectedCharacter);

    }
    public void PrevCharacter(){
        chars[selectedCharacter].SetActive(false);
        stats[selectedCharacter].SetActive(false);

        selectedCharacter -= 1;
        if(selectedCharacter < 0){
            selectedCharacter += chars.Length;  
        }
        chars[selectedCharacter].SetActive(true);
        stats[selectedCharacter].SetActive(true);

        charLabel.text = prefabNames[selectedCharacter];

        print(selectedCharacter);


    }    

}
