using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Treadmill : MonoBehaviour
{
    [SerializeField] TreadmillDirectionType _direction;
    [SerializeField] private float _speed = 1;
    [SerializeField] private SurfaceEffector2D _effector;
    [SerializeField] TMP_Text _inputNameText;

    // Start is called before the first frame update
    void Start()
    {
        RefreshSpeed();
    }

    public void SetInputameText(string text)
    {
        if (_inputNameText != null)
        {
            _inputNameText.text = text;
        }
    }

    public void InvertDirection()
    {
        _direction = _direction == TreadmillDirectionType.Right ? TreadmillDirectionType.Left : TreadmillDirectionType.Right;
        RefreshSpeed();
    }

    private void RefreshSpeed()
    {
        _effector.speed = _direction == TreadmillDirectionType.Right ? _speed : -_speed;
    }
}
