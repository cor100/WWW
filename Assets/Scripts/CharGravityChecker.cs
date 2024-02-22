using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGravityChecker : MonoBehaviour
{
    private bool isGravityDown;
    private Rigidbody2D characterRB2D;
    private static CharGravityChecker _instance;

    private void Start()
    {
        _instance = this;
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

    public static CharGravityChecker Get()
    {
        return _instance;
    }

    public bool returnGravityDown()
    {
        return isGravityDown;
    }
}
