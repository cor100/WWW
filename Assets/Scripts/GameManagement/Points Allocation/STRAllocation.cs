using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STRAllocation : MonoBehaviour
{
    private int currentNumCoins;
    private int currentStrength;
    private int newMaxStrength;
    private int prevStrength;

    public GameObject pointsRemaining;
    private PointsAllocation pointsAllocation;

    // 2 is hardcoded, information comes from "info" UI in scene
    private int strengthCost = 2;
    private Slider slider;

    private bool pointsUpdatedMethodCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentStrength = PlayerPrefs.GetInt("playerStrength");
        currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
        newMaxStrength = currentStrength;
        prevStrength = currentStrength;
        pointsAllocation = pointsRemaining.GetComponent<PointsAllocation>();
        AllocateSliderStats();   
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateNewMaxStrength();

        slider.onValueChanged.AddListener(delegate { UpdateNewMaxStrength(); });
        pointsUpdatedMethodCalled = false;
    }

    private void AllocateSliderStats()
    {
        // integer division in C# throws away the remainder
        int maxPossibleAllocatedHealth = currentNumCoins / strengthCost;

        slider.minValue = 0;
        slider.maxValue = maxPossibleAllocatedHealth;

        //Debug.Log("InitialAllocateSTR" + currentNumCoins + " " + strengthCost + " " + maxPossibleAllocatedHealth);
    }

    private void UpdateNewMaxStrength()
    {
        newMaxStrength = currentStrength + (int) slider.value;

        if (!pointsUpdatedMethodCalled)
        {
            pointsUpdatedMethodCalled = true;
            pointsAllocation.UpdatePointsFromSTR();

            currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
            prevStrength = newMaxStrength;
            //AllocateSliderStats();
        }
    }

    public int ReturnNewMaxStrength()
    {
        return newMaxStrength;
    }

    // returns how much strength has increased by
    public int ReturnStrengthChange()
    {
        return (prevStrength - newMaxStrength);
    }

    public int ReturnStrengthCost()
    {
        return strengthCost;
    }
}
