using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform Player1; // player
    public float mouseSensitivity = 100f; // sensivity
    private float xRotation = 0f; // rotire pe axa X pentru cameră
    private PlayerInput controls; // referinta către Input Action

    private InputAction lookAction;


    private void Awake()
    {
        controls = GetComponent<PlayerInput>();


        lookAction = controls.actions["Look"];
        Plook();
        //lookAction = playerA.FindAction("Look");



    }

    private void OnEnable()
    {
        lookAction.performed += _ => Plook();
        lookAction?.Enable();
    }

    private void OnDisable()
    {
        lookAction.performed -= _ => Plook();

        lookAction?.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
    }


    private void Plook()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Controlăm rotația pe axa X (sus-jos)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        Player1.localRotation = Quaternion.Euler(xRotation, Player1.localRotation.eulerAngles.y + mouseX, 0f);

    }
}