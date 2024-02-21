using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGroundChecker : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField] private float distanceForGroundedCheck = 0.1f;
    [SerializeField] private LayerMask groundMask;
    private CharacterAnimator characterAnimator;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 targetPosition = transform.position + (Vector3.down * distanceForGroundedCheck);
        Gizmos.DrawLine(transform.position, targetPosition);
    }

    private void Start()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceForGroundedCheck, groundMask);
        isGrounded = hit;
        characterAnimator.onPlayerGroundedChange(isGrounded);
    }

    public bool returnGroundedState()
    {
        return isGrounded;
    }
}
