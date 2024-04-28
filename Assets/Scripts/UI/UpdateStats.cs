using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    [SerializeField] GameObject hpLevel;
    [SerializeField] GameObject strLevel;
    [SerializeField] GameObject hpBar;
    //[SerializeField] GameObject strBar;
    private Slider hpSlider;
    private Slider strSlider;
    private GameObject player;
    // assign values of the HP and STR to be the correct ones at level
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

    // Update is called once per frame
    // Change health levels shown on HP bar as player gets hit
    void Update()
    {   
       updateHealthUI();
    }

    private void updateHealthUI(){
        if(GameObject.FindWithTag("player")){
            int health = GameObject.FindWithTag("player").GetComponent<CharStats>().ReturnCharacterHealth();
            if(hpSlider){hpSlider.value = health;}
            if(hpLevel){hpLevel.GetComponent<TextMeshProUGUI>().text = health.ToString();}

        }
    }

}
