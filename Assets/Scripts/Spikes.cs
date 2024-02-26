using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : Barrier{
    public CharacterAnimator characterAnimator;
    private float deathAnimationTime = 1;
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("player")){ isDead = true; }
        if (isDead){
            collision.gameObject.GetComponent<CharacterJump>().enabled = false;
            collision.gameObject.GetComponent<CharHorizontalMovement>().enabled = false;
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerIsMovingChanges(false);
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerGroundedChange(false);
            collision.gameObject.GetComponent<CharacterAnimator>().onPlayerDied(true);

            Invoke("ReloadScene", deathAnimationTime);
        }
    }
}