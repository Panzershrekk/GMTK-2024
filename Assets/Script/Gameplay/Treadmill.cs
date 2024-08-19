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
    [SerializeField] private Arrow _leftArrow;
    [SerializeField] private Arrow _rightArrow;

    [SerializeField] private float _initSpeedGain = 1;
    [SerializeField] private float _onSwitchSpeedGain = 5;

    private float _speedGain = 1f;
    private bool _isSetUp = false;

    public void Setup()
    {
        _speedGain = _initSpeedGain;
        _isSetUp = true;
        Refresh();
    }

    void Update()
    {
        if (_isSetUp)
        {
            Vector3 dir = _direction == TreadmillDirectionType.Right ? Vector3.right : Vector3.left;
            Vector3 translation = dir * Mathf.Abs(_effector.speed) * Time.deltaTime;

            foreach (var chain in _chains)
            {
                int currentIndex = _chains.IndexOf(chain);
                int previousIndex = currentIndex - 1;
                if (currentIndex - 1 < 0)
                {
                    previousIndex = _chains.Count - 1;
                }
                int nextIndex = currentIndex + 1;
                if (nextIndex >= _chains.Count)
                {
                    nextIndex = 0;
                }

                if (chain.transform.localPosition.x < _limitLeft.localPosition.x)
                {
                    GameObject previousChain = _chains[previousIndex];
                    chain.transform.localPosition = new Vector3(previousChain.transform.localPosition.x + 0.64f, chain.transform.localPosition.y, chain.transform.localPosition.z);
                }
                if (chain.transform.localPosition.x > _limitRight.localPosition.x)
                {
                    GameObject nextChain = _chains[nextIndex];
                    chain.transform.localPosition = new Vector3(nextChain.transform.localPosition.x - 0.64f, chain.transform.localPosition.y, chain.transform.localPosition.z);
                }
                chain.transform.localPosition += translation;
            }
            if (_direction == TreadmillDirectionType.Left && _effector.speed > -_speed)
            {
                _effector.speed -= _speedGain * Time.deltaTime;
                if (_effector.speed < -_speed)
                {
                    _effector.speed = -_speed;
                }
            }
            if (_direction == TreadmillDirectionType.Right && _effector.speed < _speed)
            {
                _effector.speed += _speedGain * Time.deltaTime;
                if (_effector.speed > _speed)
                {
                    _effector.speed = _speed;
                }
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
        _speedGain = _onSwitchSpeedGain;
        AudioManager.Instance.Play("Click");
        Refresh();
    }

    private void Refresh()
    {
        if (_leftArrow != null && _rightArrow != null)
        {
            if (_direction == TreadmillDirectionType.Left)
            {
                _rightArrow.Toggle(false);
                _leftArrow.Toggle(true);
            }
            else if (_direction == TreadmillDirectionType.Right)
            {
                _rightArrow.Toggle(true);
                _leftArrow.Toggle(false);
            }
        }
        _effector.speed = 0;
    }

}
