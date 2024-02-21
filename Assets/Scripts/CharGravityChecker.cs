using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGravityChecker : MonoBehaviour
{
    private bool isGravityDown;
    private CharacterAnimator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void CheckIfGravityDown()
    {

    }
}
