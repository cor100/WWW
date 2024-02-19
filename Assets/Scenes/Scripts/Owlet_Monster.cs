using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Owlet_Monster : MonoBehaviour
{
    public Animator playerAnimator;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSpriteRenderer;
    private Vector2 velChange = Vector2.zero;
    
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
    }

    private void Move(){
        if(Input.GetKeyDown(KeyCode.RightShift)){
            playerAnimator.SetTrigger("walk");
        }
    }
    private void ResetVelChange(){
        velChange = new Vector2(0, _playerRigidbody.velocity.y);
    }

    // separate animator and movement classes
    // use an event in the movement class to check if key is pressed, then have another method that (first checks if event is not null) and Invoke based on a condition
    // make sure to use delegate for that event function
    // animator class subscribes to the event function in the movement class (Movement.someEvent += animator_function)
    
}
