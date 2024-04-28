using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPAllocation : MonoBehaviour
{
    private int currentNumCoins;
    private int currentHealth;
    private int newMaxHealth;
    private int prevHealth;

    public GameObject pointsRemaining;
    private PointsAllocation pointsAllocation;

    // 4 is hardcoded, information comes from "info" UI in scene
    private int healthCost = 4;
    private Slider slider;

    private bool pointsUpdatedMethodCalled = false;

    // responsibility of class: working with slider to allocate HP to player given
    // a certain amount of points

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentHealth = PlayerPrefs.GetInt("playerHealth");
        currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
        newMaxHealth = currentHealth;
        prevHealth = currentHealth;
        pointsAllocation = pointsRemaining.GetComponent<PointsAllocation>();
        AllocateSliderStats();
    }

    // Update is called once per frame
    void Update()
    {
        // when the slider changes, call UpdateNewMaxHealth()
        slider.onValueChanged.AddListener(delegate { UpdateNewMaxHealth(); });
        pointsUpdatedMethodCalled = false;
    }

    // for initialising how much slider is able to allocate based on current coins
    private void AllocateSliderStats()
    {
        // integer division in C# throws away the remainder
        int maxPossibleAllocatedHealth = currentNumCoins / healthCost;

        slider.minValue = 0;
        slider.maxValue = maxPossibleAllocatedHealth;
    }

    // updating max health via PlayerPrefs & PointsAllocation class
    private void UpdateNewMaxHealth()
    {
        newMaxHealth = currentHealth + (int) slider.value;

        if (!pointsUpdatedMethodCalled)
        {
            pointsUpdatedMethodCalled = true;
            pointsAllocation.UpdatePointsFromHP();

            currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
            prevHealth = newMaxHealth;
        }   
    }

    public int ReturnNewMaxHealth()
    {
        return newMaxHealth;
    }

    // returns how much health has increased by as compared to previous allocation
    public int ReturnHealthChange()
    {
        return (prevHealth - newMaxHealth);
    }

    public int ReturnHealthCost()
    {
        return healthCost;
    }
}
