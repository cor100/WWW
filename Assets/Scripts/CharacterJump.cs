using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D characterRB2D;
    private bool isJumpBuffer;
    private CharGroundChecker groundChecker;

    private void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<CharGroundChecker>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.returnGroundedState())
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
        }
    }

    private void Jump()
    {
        // impulse applies force in a frame, whereas force applies only when the key is pressed
        characterRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
