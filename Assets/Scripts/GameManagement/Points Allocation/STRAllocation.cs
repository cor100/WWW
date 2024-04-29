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

    // 3 is hardcoded, information comes from "info" UI in scene
    private int strengthCost = 3;
    private Slider slider;

    private bool pointsUpdatedMethodCalled = false;

    // responsibility of class: working with slider to allocate STR to player given
    // a certain amount of points

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
        // when the slider changes, call UpdateNewMaxStrength()
        slider.onValueChanged.AddListener(delegate { UpdateNewMaxStrength(); });
        pointsUpdatedMethodCalled = false;
    }

    // for initialising how much slider is able to allocate based on current coins
    private void AllocateSliderStats()
    {
        // integer division in C# throws away the remainder
        int maxPossibleAllocatedHealth = currentNumCoins / strengthCost;

        slider.minValue = 0;
        slider.maxValue = maxPossibleAllocatedHealth;
    }

    // updating max strength via PlayerPrefs & PointsAllocation class
    private void UpdateNewMaxStrength()
    {
        newMaxStrength = currentStrength + (int) slider.value;

        if (!pointsUpdatedMethodCalled)
        {
            pointsUpdatedMethodCalled = true;
            pointsAllocation.UpdatePointsFromSTR();

            currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
            prevStrength = newMaxStrength;
        }
    }

    public int ReturnNewMaxStrength()
    {
        return newMaxStrength;
    }

    // returns how much strength has increased by as compared to previous allocation
    public int ReturnStrengthChange()
    {
        return (prevStrength - newMaxStrength);
    }

    public int ReturnStrengthCost()
    {
        return strengthCost;
    }
}
