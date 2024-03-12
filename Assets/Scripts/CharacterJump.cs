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
    private float coyoteTime = 0.5f;
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
        if(groundChecker.returnGroundedState()){
            coyoteTimeCounter = coyoteTime;
            numJumpsLeft = numJumps;
            if(Input.GetKeyDown(KeyCode.Space)){
                isJumpBuffer = true;
                numJumpsLeft -= 1;
            }
        }else{
            coyoteTimeCounter -= Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f){
                if(numJumpsLeft > 0){
                    isJumpBuffer = true;
                }
            }
        }

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     if(numJumpsLeft > 0){
        //         Debug.Log("true if "+numJumpsLeft);
        //         if(coyoteTimeCounter > 0f){
        //             isJumpBuffer = true;
        //             numJumpsLeft -= 1;
        //             Debug.Log(isJumpBuffer);
        //         }
        //     }else{
        //         Debug.Log("numJmpsLeft "+numJumpsLeft);
        //         Debug.Log(coyoteTimeCounter);
        //     }
        // }

        // if(groundChecker.returnGroundedState())
        // {
        //     coyoteTimeCounter = coyoteTime;
        //     numJumpsLeft = numJumps;
        // }
        // else
        // {
        //     coyoteTimeCounter -= Time.deltaTime;
        // }



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
