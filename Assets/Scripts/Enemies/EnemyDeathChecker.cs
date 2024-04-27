using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathChecker : EnemyKillChecker
{
    private int characterStrength;
    private bool isDead = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        playerEnemyCollisionY = collision.GetContact(0).point.y;
        enemyDeathLimitY = enemyCollider.bounds.max.y - jumpDeathBuffer;
        collidedObject = collision.gameObject;
        charStats = collidedObject.GetComponent<CharStats>();
        characterStrength = PlayerPrefs.GetInt("playerStrength");

        CheckDeathStatus();
    }

    private void CheckDeathStatus()
    {
        if (playerEnemyCollisionY > enemyDeathLimitY)
        {
            enemyAnimator.enemyHurt();
            PlayerBounceFromAttack();
            enemyStats.DecreaseHealth(characterStrength);
            if (enemyStats.ReturnDeathStatus())
            {
                charStats.UpdatePointsCollected();
                StartCoroutine(AnimateAndDestroy());
            }
        }
    }

    private IEnumerator AnimateAndDestroy()
    {
        isDead = true;
        enemyAnimator.enemyDied(true);
        yield return new WaitForSeconds(deathAnimationTime);
        Destroy(gameObject);
    }

    private void PlayerBounceFromAttack()
    {
        Rigidbody2D playerRB2D = collidedObject.GetComponent<Rigidbody2D>();
        playerRB2D.AddForce(collidedObject.transform.up * playerForceBounceFromAttack, ForceMode2D.Impulse);
        collidedObject.GetComponent<AudioSource>().Play();
    }

    public bool ReturnDeathStatus()
    {
        return isDead;
    }
}
