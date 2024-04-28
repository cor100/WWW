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

    void Start()
    {
        selectedCharacter = 0;
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    // Upon the press of the next arrow, switch to the stats and sprite of 
    // the next character on the list
    public void NextCharacter()
    {
        chars[selectedCharacter].SetActive(false);
        stats[selectedCharacter].SetActive(false);

        selectedCharacter = (selectedCharacter + 1) % chars.Length;
        print(selectedCharacter);
        chars[selectedCharacter].SetActive(true);
        stats[selectedCharacter].SetActive(true);

        charLabel.text = prefabNames[selectedCharacter];

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        stats[selectedCharacter].GetComponent<CharStats>().SetStatsPlayerPrefs();
    }

    // Upon the press of the back arrow, switch to the stats and sprite of 
    // the previous character on the list
    public void PrevCharacter()
    {
        chars[selectedCharacter].SetActive(false);
        stats[selectedCharacter].SetActive(false);

        selectedCharacter -= 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter += chars.Length;
        }
        chars[selectedCharacter].SetActive(true);
        stats[selectedCharacter].SetActive(true);

        charLabel.text = prefabNames[selectedCharacter];

        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        stats[selectedCharacter].GetComponent<CharStats>().SetStatsPlayerPrefs();
    }    
    

}
