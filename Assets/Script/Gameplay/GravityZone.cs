using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [SerializeField] private float _xVelocityRatio = 0.20f;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            Rigidbody2D rigidbody2D = col.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocityX = rigidbody2D.velocityX * _xVelocityRatio;
        }
    }
}
