using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TreadmillHandler : MonoBehaviour
{
    private GameInputControl _inputActions;
    [SerializeField] private Treadmill _topTreadMill;
    [SerializeField] private Treadmill _leftTreadMill;
    [SerializeField] private Treadmill _rightTreadMill;

    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new GameInputControl();
        _inputActions.Player.Enable();
        _inputActions.Player.SwitchTopTreadmill.performed += SwitchTopTreadMill;
        _inputActions.Player.SwitchLeftTreadmill.performed += SwitchLeftTreadMill;
        _inputActions.Player.SwitchRightTreadmill.performed += SwitchRightTreadMill;

    }

    //TODO, voir pour uniformiser ça
    private void SwitchTopTreadMill(InputAction.CallbackContext context)
    {
        _topTreadMill.InvertDirection();
    }

    private void SwitchLeftTreadMill(InputAction.CallbackContext context)
    {
        _leftTreadMill.InvertDirection();
    }

    private void SwitchRightTreadMill(InputAction.CallbackContext context)
    {
        _rightTreadMill.InvertDirection();
    }
}
