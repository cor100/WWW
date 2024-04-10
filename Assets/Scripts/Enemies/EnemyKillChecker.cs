using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillChecker : MonoBehaviour
{
    [SerializeField] protected float jumpDeathBuffer;
    [SerializeField] protected float playerForceBounceFromAttack;

    protected float deathAnimationTime = 1;
    protected Barrier barrier;
    protected Collider2D enemyCollider;
    protected EnemyStats enemyStats;
    protected CharStats charStats;
    protected EnemyAnimation enemyAnimator;

    private bool isKill = false;

    // variables relating to player collision with enemy
    protected float playerEnemyCollisionY;
    protected float enemyDeathLimitY;
    protected GameObject collidedObject;

    void Start()
    {
        barrier = GetComponent<Barrier>();
        enemyStats = GetComponent<EnemyStats>();
        enemyCollider = GetComponent<Collider2D>();
        enemyAnimator = GetComponent<EnemyAnimation>();
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        playerEnemyCollisionY = collision.GetContact(0).point.y;
        enemyDeathLimitY = enemyCollider.bounds.max.y - jumpDeathBuffer;
        collidedObject = collision.gameObject;
        charStats = collision.gameObject.GetComponent<CharStats>();

        CheckKillStatus();
    }

    private void CheckKillStatus()
    {
        if ((playerEnemyCollisionY <= enemyDeathLimitY) && collidedObject.CompareTag("player"))
        {
            if (!enemyStats.ReturnDeathStatus())
            {
                charStats.DecreaseCharacterHealth();

                if (charStats.ReturnDeathStatus())
                {
                    isKill = true;
                    KillPlayer();
                }   
            }
        }       
    }

    private void KillPlayer()
    {
        if (isKill)
        {
            collidedObject.GetComponent<CharacterJump>().enabled = false;
            collidedObject.GetComponent<CharHorizontalMovement>().enabled = false;
            collidedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            collidedObject.GetComponent<CharacterAnimator>().onPlayerIsMovingChanges(false);
            collidedObject.GetComponent<CharacterAnimator>().onPlayerGroundedChange(false);
            collidedObject.GetComponent<CharacterAnimator>().onPlayerDied(true);
            Invoke("CallReloadScene", deathAnimationTime);
        }
    }

        private void CallReloadScene()
    {
        barrier.ReloadScene();
    }
}
