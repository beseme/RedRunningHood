using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAllocator : MonoBehaviour
{
    [SerializeField] private PlayerController _player = null;
    [SerializeField] private LevelUI _ui = null;
    
    private InputPad _input = null;

    private Vector2 _stickAxis = Vector2.zero;
    
    private float _jumpPressed = 0;
    private float _inputX = 0;
    private float _keyVal = 0;


    private void Awake()
    {
        _input = new InputPad();
        // ---------- Actual Gamepad ----------
        _input.Gameplay.Run.performed += Stick => _stickAxis = Stick.ReadValue<Vector2>();
        _input.Gameplay.Run.canceled += Stick => _stickAxis = Vector2.zero;
        _input.Gameplay.Jump.performed += Button => Jump();
        _input.Gameplay.Jump.performed += Button => _jumpPressed = Button.ReadValue<float>();
        _input.Gameplay.Jump.canceled += Button => _jumpPressed = 0;
        _input.Gameplay.Electric.performed += ElButton => Electric();
        _input.Gameplay.Roll.performed += RollButton => StartDash(_inputX);
        _input.Gameplay.Pause.performed += PauseButton => Pause();

        _input.Keyboard.RunL.performed += Key => _keyVal = -Key.ReadValue<float>();
        _input.Keyboard.RunL.canceled += Key => _keyVal = 0;
        _input.Keyboard.RunR.performed += Key => _keyVal = Key.ReadValue<float>();
        _input.Keyboard.RunR.canceled += Key => _keyVal = 0;
        _input.Keyboard.Jump.performed += Bar => Jump();
        _input.Keyboard.Jump.performed += Bar => _jumpPressed = Bar.ReadValue<float>();
        _input.Keyboard.Jump.canceled += Bar => _jumpPressed = 0;
        _input.Keyboard.Thunder.performed += Key => Electric();
        _input.Keyboard.Ice.performed += Key => StartDash(_inputX);
    }
    
    private void OnEnable()
    {
        _input.Gameplay.Enable(); 
        _input.Keyboard.Enable();
    }

    private void OnDisable()
    {
        _input.Gameplay.Disable();
        _input.Keyboard.Disable();
    }

    private void Update()
    {
        _player.JumpPressed = _jumpPressed;
        
        // translate stick value to fixed value
        if (_stickAxis.x > .4f || _keyVal > 0)
            _inputX = 1;
        else if (_stickAxis.x < -.4f || _keyVal < 0)
            _inputX = -1;
        else
            _inputX = 0;

        _player.InputX = _inputX;
    }

    void Jump()
    {
        _player.Jump();
    }

    void Electric()
    {
        _player.Electric();
    }

    void StartDash(float input)
    {
        _player.StartDash(input);
    }

    void Pause()
    {
        _ui.Menu();
    }
}
