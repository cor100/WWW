using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D characterRB2D;
    private bool isJumpBuffer;
    private CharGroundChecker groundChecker;
    private CharGravityChecker gravChecker;
    private float coyoteTime = 0.5f;
    private float coyoteTimeCounter; 

    private void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<CharGroundChecker>();
        gravChecker = GetComponent<CharGravityChecker>();
    }

    private void Update()
    {
        if(groundChecker.returnGroundedState()){
            coyoteTimeCounter = coyoteTime;
        }else{
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0f && Input.GetKeyDown(KeyCode.Space))
        {
            isJumpBuffer = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumpBuffer)
        {
            isJumpBuffer = false;
            Jump();
            coyoteTimeCounter = 0f;

        }
    }

    private void Jump()
    {
        // impulse applies force in a frame, whereas force applies only when the key is pressed
        if (gravChecker.returnGravityDown())
        {
            characterRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            characterRB2D.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
    }

}
