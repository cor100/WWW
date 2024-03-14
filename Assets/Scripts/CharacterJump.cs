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
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private int numJumps = 1;
    private float coyoteTime = 0.08f;
    private float coyoteTimeCounter;    
    private int numJumpsLeft;
    private void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<CharGroundChecker>();
        gravChecker = GetComponent<CharGravityChecker>();
    }

    private void Update()
    {   


        if(Input.GetKeyDown(KeyCode.Space) && numJumpsLeft > 0 && coyoteTimeCounter >= 0f){
            numJumpsLeft -=1;
            isJumpBuffer = true;
        }

        if(groundChecker.returnGroundedState())
        {
            coyoteTimeCounter = coyoteTime;
            numJumpsLeft = numJumps;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
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
        jumpSoundEffect.Play();
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
