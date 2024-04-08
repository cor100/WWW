using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    
    [SerializeField] private string nextSceneName;
    [SerializeField] private GameObject[] chars;
    [SerializeField] private GameObject[] stats;
    [SerializeField] private int selectedCharacter = 0;
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

    // Start is called before the first frame update
    public void StartButton()
    {
        PlayerPrefs.GetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);

    }

}
