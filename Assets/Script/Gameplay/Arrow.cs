using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    [SerializeField] Animator animator;

    public void Toggle(bool toggled)
    {
        if (toggled)
        {
            spriteRenderer.sprite = on;
            animator.Play("ToggleOn");
        }
        else
        {
            spriteRenderer.sprite = off;
            animator.Play("ToggleOff");
        }
    }
}
