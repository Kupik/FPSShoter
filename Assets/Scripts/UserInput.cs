using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;


    // Proprietați pentru mișcare
    public Vector2 MoveInput { get; private set; }
    public bool JumpJustPressed { get; private set; }
    public bool JumpBeingHeld { get; private set; }
    public bool RunJustPressed { get; private set; }
    public bool RunReleased { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _runAction;

    private InputAction _runActionGamepad;
    private InputAction _jumpActionGamePad;

    private void Awake()
    {
        // Verificăm dacă există deja o instanță, dacă nu, o creăm
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Obținem componenta PlayerInput
        _playerInput = GetComponent<PlayerInput>();
        SetupInputActions();
    }

    public void Update()
    {
        // Actualizăm inputurile la fiecare cadru
        UpdateInputs();
    }

    public void SetupInputActions()
    {
        // Configurăm acțiunile de input
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
        _jumpActionGamePad = _playerInput.actions["JumpGamePad"];
      
        _runAction = _playerInput.actions["Run"];
        _runActionGamepad = _playerInput.actions["RunGamePad"];
    }

    public void UpdateInputs()
    {
        // Citim inputul pentru mișcare
        MoveInput = _moveAction.ReadValue<Vector2>();

        // verificam daca butonul de salt a fost apasat
        JumpJustPressed = _jumpAction.WasPressedThisFrame();
        JumpBeingHeld = _jumpAction.IsPressed();
        JumpBeingHeld = _jumpActionGamePad.IsPressed();

        //verificam daca butonul de alergare a fost apasat sau nu

        //RunJustPressed = _runAction.WasPressedThisFrame(); 
       
        RunReleased = _runAction.IsPressed() || _runActionGamepad.IsPressed();
    }
}
