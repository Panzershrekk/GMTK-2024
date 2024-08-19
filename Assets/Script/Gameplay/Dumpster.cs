using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private Transform particleParent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            Instantiate(particle, particleParent.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
