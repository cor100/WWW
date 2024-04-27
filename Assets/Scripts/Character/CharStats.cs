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

    // character strength during the level
    //protected int charStrength;

    // character's max health at the start of each level (will vary after points allocation)
    //protected int charLevelHealth;

    // points collected from past & in level (will fluctuate within each level)
    protected int pointsCollected = 0;


    protected bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        charHealth = charStartHealth;
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
    }

    public void ResetPointsCollected()
    {
        pointsCollected = 0;
    }

    public void SetStatsPlayerPrefs()
    {
        PlayerPrefs.SetInt("playerHealth", charStartHealth);
        //Debug.Log("6player Health" + PlayerPrefs.GetInt("playerHealth"));

        PlayerPrefs.SetInt("playerStrength", charStartStrength);
        //Debug.Log("6player Strength" + PlayerPrefs.GetInt("playerStrength"));

        PlayerPrefs.SetInt("pointsCollected", 0);
        PlayerPrefs.SetInt("currentLevel", 0);
    }
}

