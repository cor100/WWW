using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillChecker : MonoBehaviour
{

    public EnemyAnimation enemyAnimator;
    [SerializeField] private float jumpDeathBuffer;

    private float deathAnimationTime = 1;
    private bool isKill = false;
    private Barrier barrier;
    private Collider2D enemyCollider;

    void Start()
    {
        barrier = GetComponent<Barrier>();
        enemyAnimator = GetComponent<EnemyAnimation>();
        enemyCollider = GetComponent<Collider2D>();
    }


    //collider.bound.max.y
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float playerEnemyCollisionY = collision.GetContact(0).point.y;
        float enemyDeathLimitY = enemyCollider.bounds.max.y - jumpDeathBuffer;

        if (playerEnemyCollisionY > enemyDeathLimitY)
        {
            Debug.Log("enemy died");
            enemyAnimator.enemyDied(true);
            //Destroy(gameObject);
        }
        else if ((playerEnemyCollisionY <= enemyDeathLimitY) && collision.gameObject.CompareTag("player"))
        {
            isKill = true;
        }

        if (isKill)
        {
            collision.gameObject.GetComponent<CharacterJump>().enabled = false;
            collision.gameObject.GetComponent<CharHorizontalMovement>().enabled = false;
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerIsMovingChanges(false);
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerGroundedChange(false);
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerDied(true);
            Invoke("CallReloadScene", deathAnimationTime);
        }
    }

    private void CallReloadScene()
    {
        barrier.ReloadScene();
    }
}
