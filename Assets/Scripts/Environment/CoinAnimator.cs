using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// CoinAnimator animates the spin of the coin
public class CoinAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    
    private SpriteRenderer _coinSpriteRenderer;
    private float animateDelay = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        _coinSpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(animateCoin());
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
    IEnumerator animateCoin(){
      int frameIndex = 0;
      while(true){
        _coinSpriteRenderer.sprite = sprites[frameIndex];
        frameIndex++;
        if(frameIndex >= sprites.Length){
                frameIndex = 0;
            }
            yield return new WaitForSeconds(animateDelay);
        }
    }
    
    
}
