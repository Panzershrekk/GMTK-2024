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
        SetKeyBindingText("W", "A", "D");
    }

    public void Setup()
    {
        _topTreadMill.Setup();
        _leftTreadMill.Setup();
        _rightTreadMill.Setup();
        _spawnLeftTreadMill.Setup();
        _spawnRightTreadMill.Setup();
        _inputActions.Player.SwitchTreadmill.performed += SwitchTreadmill;
    }

    public void SwitchTreadmill(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        if (dir.x > 0.5)
        {
            _rightTreadMill.InvertDirection();
        }
        else if (dir.x < -0.5)
        {
            _leftTreadMill.InvertDirection();
        }
        else if (dir.y > 0.5)
        {
            _topTreadMill.InvertDirection();
        }
    }

    private void SetKeyBindingText(string upKey, string leftKey, string rightKey)
    {
        _topTreadMill.SetInputameText(upKey);
        _leftTreadMill.SetInputameText(leftKey);
        _rightTreadMill.SetInputameText(rightKey);
    }

    private void OnDestroy()
    {
        _inputActions.Player.SwitchTreadmill.performed -= SwitchTreadmill;
    }
}
