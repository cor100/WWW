using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinkStats : CharStats
{
    public GameObject pinkHPLevel;
    public GameObject pinkSTRLevel;

    // responsibility of class: keep track of this player's stats + initialize properly

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
