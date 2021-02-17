using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float lerpTime;

    [SerializeField] private Color objcolor;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, objcolor, lerpTime);
    }


}
