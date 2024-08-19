using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlimeObjectivePanel : MonoBehaviour
{
    [SerializeField] private GameObject _checkMark;
    [SerializeField] private TMP_Text _objectiveText;

    public void Setup(float objctive)
    {
        _objectiveText.text = objctive.ToString() + " KG";
    }

    public void ToogleObjectiveDone(bool done)
    {
        _checkMark.SetActive(done);
    }
}
