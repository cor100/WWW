using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsAllocation : MonoBehaviour
{
    private int currentPoints;
    private int newMaxPoints;

    public GameObject hpAlloc;
    public GameObject strAlloc;

    public TextMeshProUGUI textBox;

    // responsibility of class: to update the number of points left on screen based on HP & STR allocations

    // Start is called before the first frame update
    void Start()
    {
        currentPoints = PlayerPrefs.GetInt("pointsCollected");

        newMaxPoints = currentPoints;

        SetInitialPoints();
    }

    private void SetInitialPoints()
    {
        textBox.text = currentPoints.ToString();
    }

    // called from HPAllocation class
    public void UpdatePointsFromHP()
    {
        HPAllocation hpAllocation = hpAlloc.GetComponent<HPAllocation>();
        int coinsUsedForHP = hpAllocation.ReturnHealthChange() * hpAllocation.ReturnHealthCost();

        newMaxPoints += coinsUsedForHP;

        PlayerPrefs.SetInt("pointsCollected", newMaxPoints);

        GetComponent<TextMeshProUGUI>().text = newMaxPoints.ToString();
    }

    // called from STRAllocation class
    public void UpdatePointsFromSTR()
    {
        STRAllocation strAllocation = strAlloc.GetComponent<STRAllocation>();
        int coinsUsedForSTR = strAllocation.ReturnStrengthChange() * strAllocation.ReturnStrengthCost();

        newMaxPoints += coinsUsedForSTR;

        PlayerPrefs.SetInt("pointsCollected", newMaxPoints);

        GetComponent<TextMeshProUGUI>().text = newMaxPoints.ToString();
    }
}
