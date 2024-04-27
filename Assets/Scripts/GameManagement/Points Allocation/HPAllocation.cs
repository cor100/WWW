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

    // 3 is hardcoded, information comes from "info" UI in scene
    private int healthCost = 3;
    private Slider slider;

    private bool pointsUpdatedMethodCalled = false;

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
        // get newMaxHealth information from slider and store in this class
        //UpdateNewMaxHealth();

        slider.onValueChanged.AddListener(delegate { UpdateNewMaxHealth(); });
        pointsUpdatedMethodCalled = false;
    }

    private void AllocateSliderStats()
    {
        // integer division in C# throws away the remainder
        int maxPossibleAllocatedHealth = currentNumCoins / healthCost;

        slider.minValue = 0;
        slider.maxValue = maxPossibleAllocatedHealth;

        //Debug.Log("InitialAllocateHP " + currentNumCoins + " " + healthCost + " " + maxPossibleAllocatedHealth);
    }

    private void UpdateNewMaxHealth()
    {
        newMaxHealth = currentHealth + (int) slider.value;

        if (!pointsUpdatedMethodCalled)
        {
            pointsUpdatedMethodCalled = true;
            pointsAllocation.UpdatePointsFromHP();

            currentNumCoins = PlayerPrefs.GetInt("pointsCollected");
            prevHealth = newMaxHealth;
            //AllocateSliderStats();
        }   
    }

    public int ReturnNewMaxHealth()
    {
        return newMaxHealth;
    }

    // returns how much health has increased by
    public int ReturnHealthChange()
    {
        return (prevHealth - newMaxHealth);
    }

    public int ReturnHealthCost()
    {
        return healthCost;
    }
}
