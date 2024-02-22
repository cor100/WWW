using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGravityChecker : MonoBehaviour
{
    private bool isGravityDown;
    private CharacterAnimator characterAnimator;
    private Rigidbody2D characterRB2D;
    //private CharGravitySwitch charGravitySwitch;

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
        characterRB2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        checkGravityDown();
    }

    private void checkGravityDown()
    {
        if(characterRB2D.gravityScale == 1)
        {
            isGravityDown = true;
        }
        else if(characterRB2D.gravityScale == -1)
        {
            isGravityDown = false;
        }
    }

    public bool returnGravityDown()
    {
        return isGravityDown;
    }
}
