using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAllocator : MonoBehaviour
{
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
        _input.Keyboard.Jump.performed += Bar => _jumpPressed = 0;
        _input.Keyboard.Thunder.performed += Key => Electric();
        _input.Keyboard.Ice.performed += Key => StartDash(_inputX);
    }

    void Jump()
    {

    }

    void Electric()
    {

    }

    void StartDash(float input)
    {

    }

    void Pause()
    {

    }
}
