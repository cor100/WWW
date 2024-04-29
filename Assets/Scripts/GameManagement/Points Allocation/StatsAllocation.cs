using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsAllocation : MonoBehaviour
{

    public GameObject hpLevel;
    public GameObject strLevel;

    public GameObject hpAlloc;
    public GameObject strAlloc;

    // responsibility of class: to update the HP & STR numbers on screen

    // Start is called before the first frame update
    void Start()
    {
        SetInitialHPLevel();
        SetInitialSTRLevel();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHPLevel();
        UpdateSTRLevel();
    }

    private void SetInitialHPLevel()
    {
        // obtaining previous health information from PlayerPrefs
        int health = PlayerPrefs.GetInt("playerHealth");
        hpLevel.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    private void SetInitialSTRLevel()
    {
        int strength = PlayerPrefs.GetInt("playerStrength");
        strLevel.GetComponent<TextMeshProUGUI>().text = strength.ToString();
    }

    // when there is NewMaxHealth, update HP
    private void UpdateHPLevel()
    {
        int newMaxHealth = hpAlloc.GetComponent<HPAllocation>().ReturnNewMaxHealth();
        hpLevel.GetComponent<TextMeshProUGUI>().text = newMaxHealth.ToString();
    }

    // when there is NewMaxHealth, update STR
    private void UpdateSTRLevel()
    {
        int newMaxStrength = strAlloc.GetComponent<STRAllocation>().ReturnNewMaxStrength();
        strLevel.GetComponent<TextMeshProUGUI>().text = newMaxStrength.ToString();
    }
}
