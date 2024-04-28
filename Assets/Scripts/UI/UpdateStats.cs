using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    [SerializeField] GameObject hpLevel;
    [SerializeField] GameObject strLevel;
    [SerializeField] GameObject hpBar;
    //[SerializeField] GameObject strBar;
    private Slider hpSlider;
    private Slider strSlider;

    // assign values of the HP and STR to be the correct ones at level start
    void Start()
    {
        if(hpBar){
            hpSlider = hpBar.GetComponent<Slider>();
        }
        
        int initHealth = PlayerPrefs.GetInt("playerHealth");
        int initStrength = PlayerPrefs.GetInt("playerStrength");
        //strSlider.value = initStrength;
        if(hpSlider){
            hpSlider.maxValue = initHealth;
            hpSlider.value = hpSlider.maxValue;
        }
        

        if(hpLevel){
            hpLevel.GetComponent<TextMeshProUGUI>().text = initHealth.ToString();
        }
        if(strLevel){
            strLevel.GetComponent<TextMeshProUGUI>().text = initStrength.ToString();
        }

    }

    // Update health value as it changes
    void Update()
    {
        int health = GameObject.FindWithTag("player").GetComponent<CharStats>().ReturnCharacterHealth();
        if(hpSlider){hpSlider.value = health;}
        if(hpLevel){hpLevel.GetComponent<TextMeshProUGUI>().text = health.ToString();}
    }

}
