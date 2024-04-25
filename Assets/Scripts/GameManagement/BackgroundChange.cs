using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public static BackgroundChange Instance;

    SpriteRenderer spriteRender;
    [Range(0f, 1f)]
    public float fadeToRedAmt = 0f;

    // Takes care of how fast it will fade
    public float fadingSpeed = 0.05f;

    private bool fadedToRed = false;

    //private void Awake()
    //{
    //    Instance = this;
    //}

    private void Start()
    {
        Instance = this;
        spriteRender = GetComponent<SpriteRenderer>();
        Color color = spriteRender.material.color;

        color.g = 1f;
        color.b = 1f;

        spriteRender.material.color = color;
    }

    IEnumerator FadeToRed()
    {
        for(float i=1f; i >= fadeToRedAmt; i -= 0.05f)
        {
            Color color = spriteRender.material.color;

            color.g = i;
            color.b = i;

            spriteRender.material.color = color;

            yield return new WaitForSeconds(fadingSpeed);
        }

        fadedToRed = true;
      
    }

    // Method to start fading courotine
   public void StartFade()
    {
        StartCoroutine("FadeToRed");
    }

   public bool returnRedBackgroundStatus()
    {
        return fadedToRed;
    }
}
