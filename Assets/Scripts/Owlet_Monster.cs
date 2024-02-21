using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owlet_Monster : MonoBehaviour
{
    public Animator playerAnimator;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSpriteRenderer;
    private Vector2 velChange = Vector2.zero;
    public bool grounded = false;
    public LayerMask groundMask;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        _playerRigidbody.velocity = velChange;
        ResetVelChange();
        UpdateGrounding();
    }

    private void Move(){
        if(Input.GetKeyDown(KeyCode.RightShift)){
            playerAnimator.SetTrigger("walk");  
        }
    }

    private void Jump()
    {
        
    }

    private void ResetVelChange(){
        velChange = new Vector2(0, _playerRigidbody.velocity.y);
    }

    private void UpdateGrounding()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.1f, groundMask);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.1f, Color.red);
        if(hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        
    }

    // separate animator and movement classes
    // use an event in the movement class to check if key is pressed, then have another method that (first checks if event is not null) and Invoke based on a condition
    // make sure to use delegate for that event function
    // animator class subscribes to the event function in the movement class (Movement.someEvent += animator_function)

}
