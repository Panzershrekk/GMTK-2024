using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    public void Toggle(bool toggled)
    {
        if (toggled)
        {
            spriteRenderer.sprite = on;
        }
        else
        {
            spriteRenderer.sprite = off;
        }
    }
}
