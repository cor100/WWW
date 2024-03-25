using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWalkChecker : MonoBehaviour
{
    private bool isWalking;
    private CharacterAnimator characterAnimator;
    private CharHorizontalMovement charHorizontalMovement;

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
        charHorizontalMovement = GetComponent<CharHorizontalMovement>();
    }

    private void Update()
    {
        CheckIfWalking();
    }

    private void CheckIfWalking()
    {
        isWalking = charHorizontalMovement.returnWalkingState();
        characterAnimator.onPlayerIsMovingChanges(isWalking);
    }
}
