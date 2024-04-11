using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    // responsability of class: to animate class

    public Animator enemyAnimator;

    public void enemyDied(bool isDead)
    {
        enemyAnimator.SetBool("isDead", isDead);
    }

    public void enemyHurt()
    {
        enemyAnimator.SetTrigger("isHurt");
    }
}
