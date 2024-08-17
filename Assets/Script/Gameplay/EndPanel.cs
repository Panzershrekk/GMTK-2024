using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] float _showPanelFadePower = 0.7f;
    [SerializeField] float _showPanelTime = 1f;
    [SerializeField] CanvasGroup _canvasGroup;

    public void Display(bool victory)
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(_showPanelFadePower, _showPanelTime);
    }
}
