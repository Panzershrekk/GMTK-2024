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
    [SerializeField] private List<GameObject> _chains = new List<GameObject>();
    [SerializeField] private Transform _limitRight;
    [SerializeField] private Transform _limitLeft;

    // Start is called before the first frame update
    void Start()
    {
        RefreshSpeed();
    }

    void Update()
    {
        Vector3 dir = _direction == TreadmillDirectionType.Right ?  Vector3.right :  Vector3.left;
        Vector3 translation = dir * 5f * Time.deltaTime;

        foreach (var chain in _chains)
        {
            //chain.transform.Translate(translation);
            chain.transform.position += translation;
            if (chain.transform.position.x < _limitLeft.position.x)
            {
                chain.transform.position = new Vector3(_limitRight.position.x, chain.transform.position.y, chain.transform.position.z);
            }
            if (chain.transform.position.x > _limitRight.position.x)
            {
                chain.transform.position = new Vector3(_limitLeft.position.x, chain.transform.position.y, chain.transform.position.z);
            }
        }
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
