using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] private int startHealth;
    SpriteRenderer spriteRender;

    private int currentHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        spriteRender = GetComponent<SpriteRenderer>();
        updateColor();
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
        updateColor();
        
        
    }

    private void updateColor()
    {
        switch (currentHealth)
        {
            case 3:
                spriteRender.material.color = new Color(1f, 0f, 0f); // Red
                break;
            case 2:
                spriteRender.material.color = new Color(1f, 1f, 0f); // Yellow
                break;
            case 1:
                spriteRender.material.color = new Color(1f, 1f, 1f); // Green
                break;
        }
    }

    public bool ReturnDeathStatus()
    {
        return isDead;
    }
}
