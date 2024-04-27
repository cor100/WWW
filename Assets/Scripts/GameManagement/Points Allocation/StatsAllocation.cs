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

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("player Health" + PlayerPrefs.GetInt("playerHealth"));
        //Debug.Log("player Strength" + PlayerPrefs.GetInt("playerStrength"));
        //Debug.Log("points collected" + PlayerPrefs.GetInt("pointsCollected"));

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
        //Debug.Log("PlayerPrefHealth " + PlayerPrefs.GetInt("playerHealth"));
        int health = PlayerPrefs.GetInt("playerHealth");
        hpLevel.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    private void SetInitialSTRLevel()
    {
        //Debug.Log("PlayerPrefStrength " + PlayerPrefs.GetInt("playerStrength"));
        int strength = PlayerPrefs.GetInt("playerStrength");
        strLevel.GetComponent<TextMeshProUGUI>().text = strength.ToString();
    }

    private void UpdateHPLevel()
    {
        int newMaxHealth = hpAlloc.GetComponent<HPAllocation>().ReturnNewMaxHealth();
        hpLevel.GetComponent<TextMeshProUGUI>().text = newMaxHealth.ToString();
    }

    private void UpdateSTRLevel()
    {
        int newMaxStrength = strAlloc.GetComponent<STRAllocation>().ReturnNewMaxStrength();
        strLevel.GetComponent<TextMeshProUGUI>().text = newMaxStrength.ToString();
    }
}
