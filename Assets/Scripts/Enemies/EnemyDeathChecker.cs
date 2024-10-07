using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathChecker : EnemyKillChecker
{
    [SerializeField] ParticleSystem deathParticles;
    private int characterStrength;
    private bool isDead = false;

    // responsibility of class: to check if the enemy has died (from player jumping on it)
    // inherits from EnemyKillChecker class


    // checking the type of collision (player jumping on top or player hitting it)
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        playerEnemyCollisionY = collision.GetContact(0).point.y;
        enemyDeathLimitY = enemyCollider.bounds.max.y - jumpDeathBuffer;
        collidedObject = collision.gameObject;
        charStats = collidedObject.GetComponent<CharStats>();

        characterStrength = PlayerPrefs.GetInt("playerStrength");

        CheckDeathStatus();
    }

    // check if enemy has died after getting hit
    private void CheckDeathStatus()
    {
        if (playerEnemyCollisionY > enemyDeathLimitY)
        {
            enemyAnimator.enemyHurt();
            PlayerBounceFromAttack();
            enemyStats.DecreaseHealth(characterStrength);
            if (enemyStats.ReturnDeathStatus())
            {
                StartCoroutine(AnimateAndDestroy());
            }
        }
    }

    // animating and destroying enemy; updating points for player
    private IEnumerator AnimateAndDestroy()
    {
        isDead = true;
        enemyAnimator.enemyDied(true);

        yield return new WaitForSeconds(deathAnimationTime);
        Destroy(gameObject);
        charStats.UpdatePointsCollected();
    }

    // making the player bounce after jumping on an enemy
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
