using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] protected int charStartHealth;
    [SerializeField] protected int charStartStrength;

    protected int charHealth;
    protected int charStrength;

    protected int charLevelHealth;

    protected int pointsCollected = 0;

    protected bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        charHealth = charStartHealth;
        charStrength = charStartStrength;
        charLevelHealth = charStartHealth;
    }

    public int ReturnCharacterHealth()
    {
        return charHealth;
    }

    public int ReturnCharacterStrength()
    {
        return charStrength;
    }

    public void DecreaseCharacterHealth(int attackStrength=1)
    {
        charHealth -= attackStrength;

        if(charHealth <= 0)
        {
            isDead = true;
        }
    }

    public void ResetCharacterHealth()
    {
        charHealth = charLevelHealth;
    }

    public void IncreaseCharacterTotalHealth(int healthIncrease)
    {
        charLevelHealth += healthIncrease;
    }

    public void IncreaseCharacterStrength(int strengthIncrease)
    {
        charStrength += strengthIncrease;
    }

    public bool ReturnDeathStatus()
    {
        return isDead;
    }

    public void UpdatePointsCollected(int pointsCollected = 1)
    {
        pointsCollected += pointsCollected;
    }

    public void ResetPointsCollected()
    {
        pointsCollected = 0;
    }
}
