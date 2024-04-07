using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillChecker : MonoBehaviour
{
    [SerializeField] private float jumpDeathBuffer;
    [SerializeField] private float playerForceBounceFromAttack;

    private float deathAnimationTime = 1;
    private bool isKill = false;
    private Barrier barrier;
    private Collider2D enemyCollider;
    private EnemyAnimation enemyAnimator;

    private float playerEnemyCollisionY;
    private float enemyDeathLimitY;
    private GameObject collidedObject;

    void Start()
    {
        barrier = GetComponent<Barrier>();
        enemyAnimator = GetComponent<EnemyAnimation>();
        enemyCollider = GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerEnemyCollisionY = collision.GetContact(0).point.y;
        enemyDeathLimitY = enemyCollider.bounds.max.y - jumpDeathBuffer;
        collidedObject = collision.gameObject;

        print(playerEnemyCollisionY);
        print(enemyDeathLimitY);

        StartCoroutine(CheckDeathStatus());
    }

    private IEnumerator CheckDeathStatus()
    {

        if (playerEnemyCollisionY > enemyDeathLimitY)
        {
            PlayerBounceFromAttack();
            enemyAnimator.enemyDied(true);
            yield return new WaitForSeconds(deathAnimationTime);
            Destroy(gameObject);
        }

        else if ((playerEnemyCollisionY <= enemyDeathLimitY) && collidedObject.CompareTag("player"))
        {
            isKill = true;
            KillPlayer();
        }

        yield return null;
    }

    private void PlayerBounceFromAttack()
    {
        Rigidbody2D playerRB2D = collidedObject.GetComponent<Rigidbody2D>();
        playerRB2D.AddForce(collidedObject.transform.up * playerForceBounceFromAttack, ForceMode2D.Impulse);
    }

    private void KillPlayer()
    {
        if (isKill)
        {
            collidedObject.GetComponent<CharacterJump>().enabled = false;
            collidedObject.GetComponent<CharHorizontalMovement>().enabled = false;
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
