using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHorizontalMovement : MonoBehaviour
{
    private Rigidbody2D characterRB2D;
    private SpriteRenderer characterSpriteRenderer;
    private bool isWalkBuffer;
    private bool isWalking;

    [SerializeField] private float airMovementSpeed = 2;
    [SerializeField] private float groundMovementSpeed = 4;

    private CharGroundChecker groundChecker;
    private Vector2 velChange = Vector2.zero;

    private CharGravityChecker charGravityChecker;


    // Start is called before the first frame update
    void Start()
    {
        characterRB2D = GetComponent<Rigidbody2D>();
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponent<CharGroundChecker>();
        charGravityChecker = GetComponent<CharGravityChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWalking();
        CheckWalkBuffer();
    }

    private void FixedUpdate()
    {
        if (isWalkBuffer)
        {
            MoveHorizontally();
            isWalkBuffer = false;
            velChange = Vector2.zero;
        }
    }

    private void CheckWalkBuffer()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            isWalkBuffer = true;
        }
    }

    private void CheckWalking()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void MoveHorizontally()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (charGravityChecker.returnGravityDown())
            {
                characterSpriteRenderer.flipX = false;
            } else
            {
                characterSpriteRenderer.flipX = true;
            }
            
            if (groundChecker.returnGroundedState())
            {
                velChange.x = groundMovementSpeed;
            }
            else
            {
                velChange.x = airMovementSpeed;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (charGravityChecker.returnGravityDown())
            {
                characterSpriteRenderer.flipX = true;
            }
            else
            {
                characterSpriteRenderer.flipX = false;
            }

            if (groundChecker.returnGroundedState())
            {
                velChange.x = -groundMovementSpeed;
            }
            else
            {
                velChange.x = -airMovementSpeed;
            }
        }

        velChange.y = characterRB2D.velocity.y;
        characterRB2D.velocity = velChange;
    }

    public bool returnWalkingState()
    {
        return isWalking;
    }

}
