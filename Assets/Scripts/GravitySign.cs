using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySign : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite upSign;
    [SerializeField] private Sprite downSign;
    //private CharGravityChecker gravityChecker;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = downSign;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if(CharGravityChecker.Get().returnGravityDown())
        {
            spriteRenderer.sprite = downSign;
        }
        else
        {
            spriteRenderer.sprite = upSign;
        }
    }


}
