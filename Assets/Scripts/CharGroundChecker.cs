using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGroundChecker : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField] private float distanceForGroundedCheck = 0.1f;
    [SerializeField] private LayerMask groundMask;
    private CharacterAnimator characterAnimator;
    private CharGravityChecker charGravityChecker;
    private Vector2 vectorForGroundedCheck;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 targetPosition = transform.position + ((Vector3) vectorForGroundedCheck * distanceForGroundedCheck);
        Gizmos.DrawLine(transform.position, targetPosition);
    }

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
        charGravityChecker = GetComponent<CharGravityChecker>();
        vectorForGroundedCheck = Vector2.down;
    }

    private void Update()
    {
        CheckGravityDirection();
        CheckIfGrounded();
    }

    private void CheckGravityDirection()
    {
        if (charGravityChecker.returnGravityDown())
        {
            vectorForGroundedCheck = Vector2.down;
        }
        else
        {
            vectorForGroundedCheck = Vector2.up;
        }
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorForGroundedCheck, distanceForGroundedCheck, groundMask);
        isGrounded = hit;
        characterAnimator.onPlayerGroundedChange(isGrounded);
    }

    public bool returnGroundedState()
    {
        return isGrounded;
    }
}
