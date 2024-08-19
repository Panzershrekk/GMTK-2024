using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CombinationPart
{
    public AlimentDefinition alimentDefinition;
    public bool isValidated = false;
}

public class Combination : MonoBehaviour
{
    [SerializeField] Animator _animatorCombi;
    [SerializeField] private CombinationDisplayer _combinationDisplayer;
    private List<CombinationPart> _combinationPart = new List<CombinationPart>();

    public void GenerateNewCombination(int combinationSize)
    {
        _combinationPart.Clear();
        for (int i = 0; i < combinationSize; i++)
        {
            AlimentDefinition alimentDefinition = GameManager.Instance.GetRandomAlimentFromPossibility();
            CombinationPart combinationPart = new CombinationPart
            {
                alimentDefinition = alimentDefinition,
                isValidated = false
            };
            _combinationPart.Add(combinationPart);
        }
        _combinationDisplayer.RefreshUI(_combinationPart);
    }

    public bool CheckForCombination(AlimentDefinition alimentDefinition)
    {
        int validCount = 0;
        bool hasValidated = false;

        foreach (CombinationPart combinationPart in _combinationPart)
        {
            if (hasValidated == false && combinationPart.isValidated == false && alimentDefinition.alimentType == combinationPart.alimentDefinition.alimentType)
            {
                combinationPart.isValidated = true;
                hasValidated = true;
            }
            if (combinationPart.isValidated == true)
            {
                validCount += 1;
            }
        }
        if (hasValidated == false)
        {
            Reset();
        }
        _combinationDisplayer.RefreshUI(_combinationPart);
        if (validCount == _combinationPart.Count)
        {
            _animatorCombi.Play("Hide");
            return true;
        }
        return false;
    }

    private void Reset()
    {
        _animatorCombi.Play("WrongCombinationAnim");
        foreach (CombinationPart combinationPart in _combinationPart)
        {
            combinationPart.isValidated = false;
        }
    }

    public List<CombinationPart> GetCombinationPart()
    {
        return _combinationPart;
    }
}
