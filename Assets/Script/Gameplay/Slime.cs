using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slime : MonoBehaviour
{

    [SerializeField] private TMP_Text _sizeText;
    [SerializeField] private TMP_Text _objectiveText;

    [SerializeField] private int _combinationSize;
    [SerializeField] private Combination _combination;
    [SerializeField] private float _sizeGainPerSuccess = 1f;
    private float _currentSize = 1;
    private float _objective = 0;

    public void Setup(float slimeObjective)
    {
        _combination.GenerateNewCombination(_combinationSize);
        _objective = slimeObjective;
        _objectiveText.text = _objective.ToString();
        _sizeText.text = _currentSize.ToString();

    }

    public void GainSize()
    {
        _currentSize += _sizeGainPerSuccess;
        _sizeText.text = _currentSize.ToString();
    }

    public Combination GetCombination()
    {
        return _combination;
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
                    GainSize();
                }
            }
            Destroy(col.gameObject);
        }
    }
}
