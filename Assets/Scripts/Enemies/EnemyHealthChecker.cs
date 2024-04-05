using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthChecker : MonoBehaviour
{

    [SerializeField] private int enemyStartHealth;
    private int enemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected int ReturnEnemyHealth()
    {
        return enemyHealth;
    }

    protected void EnemyDamaged()
    {
        enemyHealth -= 1;
    }
}
