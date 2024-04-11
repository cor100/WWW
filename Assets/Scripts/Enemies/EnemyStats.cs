using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] private int startHealth;

    private int currentHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    public int ReturnCurrentHealth()
    {
        return currentHealth;
    }

    public void DecreaseHealth(int attackStrength)
    {
        currentHealth -= attackStrength;

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public bool ReturnDeathStatus()
    {
        return isDead;
    }
}
