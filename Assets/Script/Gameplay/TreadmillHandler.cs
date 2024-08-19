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
    [SerializeField] private Treadmill _spawnLeftTreadMill;
    [SerializeField] private Treadmill _spawnRightTreadMill;

    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new GameInputControl();
        _inputActions.Player.Enable();
        _topTreadMill.SetInputameText(_inputActions.Player.SwitchTopTreadmill.name);
        _leftTreadMill.SetInputameText(_inputActions.Player.SwitchLeftTreadmill.name);
        _rightTreadMill.SetInputameText(_inputActions.Player.SwitchRightTreadmill.name);

    }

    public void Setup()
    {
        _topTreadMill.Setup();
        _leftTreadMill.Setup();
        _rightTreadMill.Setup();
        _spawnLeftTreadMill.Setup();
        _spawnRightTreadMill.Setup();
        
        _inputActions.Player.SwitchTopTreadmill.performed += SwitchTopTreadMill;
        _inputActions.Player.SwitchLeftTreadmill.performed += SwitchLeftTreadMill;
        _inputActions.Player.SwitchRightTreadmill.performed += SwitchRightTreadMill;
    }

    //TODO, voir pour uniformiser ça
    private void SwitchTopTreadMill(InputAction.CallbackContext context)
    {
        _topTreadMill.InvertDirection();
        Debug.Log(_inputActions.Player.SwitchTopTreadmill.bindings[0].id);
    }

    private void SwitchLeftTreadMill(InputAction.CallbackContext context)
    {
        _leftTreadMill.InvertDirection();
    }

    private void SwitchRightTreadMill(InputAction.CallbackContext context)
    {
        _rightTreadMill.InvertDirection();
    }

    private void OnDestroy()
    {
        _inputActions.Player.SwitchTopTreadmill.performed -= SwitchTopTreadMill;
        _inputActions.Player.SwitchLeftTreadmill.performed -= SwitchLeftTreadMill;
        _inputActions.Player.SwitchRightTreadmill.performed -= SwitchRightTreadMill;
    }
}
