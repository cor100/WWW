using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillChecker : MonoBehaviour
{

    public CharacterAnimator characterAnimator;
    private float deathAnimationTime = 1;
    private bool isDead = false;
    private Barrier barrier;

    void Start()
    {
        barrier = GetComponent<Barrier>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isDead = true;
        }

        if (isDead)
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
