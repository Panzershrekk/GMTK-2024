using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] GameObject _victory;
    [SerializeField] GameObject _loose;

    public void Display(bool victory)
    {
        _victory.SetActive(victory);
        _loose.SetActive(!victory);
    }
}
