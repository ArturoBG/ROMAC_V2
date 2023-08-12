using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public SimpleControls playerInput;
    public SimpleControls.GameplayActions gameplayActions;
    //
    //reference to scripts
    public PlayerLocomotion playerLocomotion;
    public PlayerCamera playerCamera;

    private void Awake()
    {
        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;

        //callback to context
        
    }

    private void Update()
    {
        playerLocomotion.MoveCharacter(gameplayActions.move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerCamera.ProcessLook(gameplayActions.look.ReadValue<Vector2>());
    }


    private void OnEnable()
    {
        gameplayActions.Enable();
    }

    private void OnDisable()
    {
        gameplayActions.Disable();
    }
}
