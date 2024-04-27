using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueStats : CharStats
{
    public GameObject blueHPLevel;
    public GameObject blueSTRLevel;

    // Start is called before the first frame update
    void Start()
    {
        charHealth = charStartHealth;

        SetInitialHPLevel();
        SetInitialSTRLevel();
        SetStatsPlayerPrefs();
    }

    private void SetInitialHPLevel()
    {
        blueHPLevel.GetComponent<TextMeshProUGUI>().text = charStartHealth.ToString();
    }

    private void SetInitialSTRLevel()
    {
        blueSTRLevel.GetComponent<TextMeshProUGUI>().text = charStartStrength.ToString();
    }
}
