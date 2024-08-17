using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private int _combinationSize;
    [SerializeField] private Combination _combination;
    private int _size = 1;
    public void Start()
    {
        _combination.GenerateNewCombination(_combinationSize);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            EddibleAliment eddibleAliment = col.gameObject.GetComponent<EddibleAliment>();
            if (eddibleAliment != null)
            {
                //_combination.CheckForCombination(eddibleAliment.GetAlimentDefinition());
                if (_combination.CheckForCombination(eddibleAliment.GetAlimentDefinition()) == true)
                {
                    _combination.GenerateNewCombination(_combinationSize);
                }
            }
            Destroy(col.gameObject);
        }
    }
}
