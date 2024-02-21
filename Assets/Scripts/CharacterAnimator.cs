using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    // responsability of class: to animate class

    public Animator characterAnimator;

    public void onPlayerGroundedChange(bool isGrounded)
    {
        characterAnimator.SetBool("isGrounded", isGrounded);
    }

    public void onPlayerIsMovingChanges(bool isWalking)
    {
        characterAnimator.SetBool("isWalking", isWalking);
    }
}
