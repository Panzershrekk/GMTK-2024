using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombinationPart : MonoBehaviour
{
    [SerializeField] Image _outline;
    [SerializeField] Image _image;

    public void Setup(CombinationPart combinationPart)
    {
        //_outline.sprite = imgToDisplay;
        _outline.gameObject.SetActive(combinationPart.isValidated);
        _image.sprite = combinationPart.alimentDefinition.alimentSprite;
    }
}
