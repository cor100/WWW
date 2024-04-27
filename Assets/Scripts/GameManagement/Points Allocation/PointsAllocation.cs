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

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("pointsCollected"));

        currentPoints = PlayerPrefs.GetInt("pointsCollected");
        //Debug.Log(currentPoints);

        newMaxPoints = currentPoints;

        SetInitialPoints();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdatePointsFromHP();
        //UpdatePointsFromSTR();
    }

    private void SetInitialPoints()
    {
        textBox.text = currentPoints.ToString();
    }

    public void UpdatePointsFromHP()
    {
        HPAllocation hpAllocation = hpAlloc.GetComponent<HPAllocation>();
        int coinsUsedForHP = hpAllocation.ReturnHealthChange() * hpAllocation.ReturnHealthCost();

        //Debug.Log("coinsUsedForHP " + hpAllocation.ReturnHealthChange() + " " + hpAllocation.ReturnHealthCost());

        //Debug.Log("newMaxPoints " + newMaxPoints);
        newMaxPoints += coinsUsedForHP;
        //Debug.Log("newMaxPoints " + newMaxPoints);

        PlayerPrefs.SetInt("pointsCollected", newMaxPoints);

        GetComponent<TextMeshProUGUI>().text = newMaxPoints.ToString();
    }

    public void UpdatePointsFromSTR()
    {
        STRAllocation strAllocation = strAlloc.GetComponent<STRAllocation>();
        int coinsUsedForSTR = strAllocation.ReturnStrengthChange() * strAllocation.ReturnStrengthCost();

        newMaxPoints += coinsUsedForSTR;

        PlayerPrefs.SetInt("pointsCollected", newMaxPoints);

        GetComponent<TextMeshProUGUI>().text = newMaxPoints.ToString();
    }
}
