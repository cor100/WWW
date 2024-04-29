using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    // the health & strength stats of the character at level 1
    [SerializeField] protected int charStartHealth;
    [SerializeField] protected int charStartStrength;

    // character health during the level (will fluctuate within each level)
    protected int charHealth;

    // points collected from past & in level (will fluctuate within each level)
    protected int pointsCollected = 0;


    protected bool isDead = false;
    private PointStats pointStats;

    // responsibility of class: to keep track of the player's health & strength stats

    // Start is called before the first frame update
    void Start()
    {
        charHealth = PlayerPrefs.GetInt("playerHealth");
        pointStats = FindObjectOfType<PointStats>();
    }

    public int ReturnCharacterHealth()
    {
        return charHealth;
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
        // using PlayerPrefs to keep track of variables across scenes
        charHealth = PlayerPrefs.GetInt("playerHealth");
    }

    public void IncreaseCharacterTotalHealth(int healthIncrease)
    {
        PlayerPrefs.SetInt("playerHealth", PlayerPrefs.GetInt("playerHealth") + healthIncrease);
    }

    public void IncreaseCharacterStrength(int strengthIncrease)
    {
        PlayerPrefs.SetInt("playerStrength", PlayerPrefs.GetInt("playerStrength") + strengthIncrease);
    }

    public bool ReturnDeathStatus()
    {
        return isDead;
    }

    public void UpdatePointsCollected(int pointsCollected = 1)
    {
        pointsCollected += pointsCollected;
        pointStats.UpdatePointsCollected();

    }

    public void ResetPointsCollected()
    {
        pointsCollected = 0;
    }

    // to use for initialising player stats after players have selected a character
    public void SetStatsPlayerPrefs()
    {
        PlayerPrefs.SetInt("playerHealth", charStartHealth);
        PlayerPrefs.SetInt("playerStrength", charStartStrength);
        PlayerPrefs.SetInt("pointsCollected", 0);
        PlayerPrefs.SetInt("currentLevel", 0);
    }
}

