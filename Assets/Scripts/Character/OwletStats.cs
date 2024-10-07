using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OwletStats : CharStats
{
    public GameObject owlHPLevel;
    public GameObject owlSTRLevel;

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
        owlHPLevel.GetComponent<TextMeshProUGUI>().text = charStartHealth.ToString();
    }

    private void SetInitialSTRLevel()
    {
        owlSTRLevel.GetComponent<TextMeshProUGUI>().text = charStartStrength.ToString();
    }
}
