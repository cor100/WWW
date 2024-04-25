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
    [SerializeField] List<Vector2> health_strength;
    private string[] prefabNames = {"Owl", "Blue", "Pink"};
    void Start(){
        selectedCharacter = 0;
        SetPlayerStats();
        print(selectedCharacter);
    }

    public void NextCharacter(){
        chars[selectedCharacter].SetActive(false);
        stats[selectedCharacter].SetActive(false);

        selectedCharacter = (selectedCharacter + 1) % chars.Length;
        print(selectedCharacter);
        chars[selectedCharacter].SetActive(true);
        stats[selectedCharacter].SetActive(true);

        charLabel.text = prefabNames[selectedCharacter];
        SetPlayerStats();
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
        SetPlayerStats();


    }    
    
    // update the chosen character, character's health and strength, in PlayerPrefs to store for
    // later use
    private void SetPlayerStats(){
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        PlayerPrefs.SetInt("playerHealth", (int)health_strength[selectedCharacter][0]);
        PlayerPrefs.SetInt("playerStrength", (int)health_strength[selectedCharacter][1]);
    }

}
