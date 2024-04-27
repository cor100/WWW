using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinkStats : CharStats
{
    public GameObject pinkHPLevel;
    public GameObject pinkSTRLevel;

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
        pinkHPLevel.GetComponent<TextMeshProUGUI>().text = charStartHealth.ToString();
    }

    private void SetInitialSTRLevel()
    {
        pinkSTRLevel.GetComponent<TextMeshProUGUI>().text = charStartStrength.ToString();
    }
}
