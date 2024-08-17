using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombinationPart : MonoBehaviour
{
    [SerializeField] Image _outline;
    [SerializeField] Image _image;

    public void Setup(Sprite imgToDisplay, bool displayOutline)
    {
        _outline.sprite = imgToDisplay;
        _outline.gameObject.SetActive(displayOutline);
        _image.sprite = imgToDisplay;
    }
}
