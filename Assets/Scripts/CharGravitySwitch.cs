using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGravitySwitch : MonoBehaviour
{
    private Rigidbody2D characterRB2D;
    private bool isGravityBuffer;
    private CharGroundChecker groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<CharGroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGravityBuffer();
    }

    private void FixedUpdate()
    {
        if (isGravityBuffer)
        {
            SwitchGravity();
            isGravityBuffer = false;
        }
    }

    private void SwitchGravity()
    {
        characterRB2D.gravityScale *= -1;
        transform.Rotate(0, 0, 180);
        print(characterRB2D.gravityScale);
    }

    private void CheckGravityBuffer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && groundChecker.returnGroundedState())
        {
            isGravityBuffer = true;
        }
    }

}
