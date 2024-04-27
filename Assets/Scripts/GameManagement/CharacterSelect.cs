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
        print(selectedCharacter);
    }

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
    
    //// update the chosen character, character's health and strength, in PlayerPrefs to store for
    //// later use
    //private void SetPlayerStats()
    //{
    //    //Debug.Log("Char Stats Health" + stats[selectedCharacter].GetComponent<CharStats>().ReturnCharacterHealth());
    //    //Debug.Log("Char Stats Strength" + stats[selectedCharacter].GetComponent<CharStats>().ReturnCharacterStrength());

    //    //PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    //    //PlayerPrefs.SetInt("playerHealth", stats[selectedCharacter].GetComponent<CharStats>().ReturnCharacterHealth());
    //    //Debug.Log("Player Health" + PlayerPrefs.GetInt("playerHealth"));
    //    ////PlayerPrefs.SetInt("playerHealth", (int)health_strength[selectedCharacter][0]);
    //    //PlayerPrefs.SetInt("playerStrength", stats[selectedCharacter].GetComponent<CharStats>().ReturnCharacterStrength());
    //    //Debug.Log("Player Strength" + PlayerPrefs.GetInt("playerStrength"));
    //    ////PlayerPrefs.SetInt("playerStrength", (int)health_strength[selectedCharacter][1]);
    //    //PlayerPrefs.SetInt("pointsCollected", 0);

    //    //stats[selectedCharacter].GetComponent<CharStats>().SetStatsPlayerPrefs();

    //}

}
