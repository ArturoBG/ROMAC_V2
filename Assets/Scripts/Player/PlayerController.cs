using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SimpleControls playerInput;
    public SimpleControls.GameplayActions gameplayActions;
    //
    //reference to scripts
    public PlayerLocomotion playerLocomotion;
    public PlayerCamera playerCamera;
    public HealthScript healthScript;
    private void Awake()
    {
        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;
        playerLocomotion = GetComponent<PlayerLocomotion>();
        //callback to context
        //attack left hand 
        gameplayActions.attack.performed += ctx => playerLocomotion.Attack();

        //attack/shield right hand
        gameplayActions.secondaryAttack.performed += ctx => playerLocomotion.Shield(true);
        gameplayActions.secondaryAttack.canceled += ctx => playerLocomotion.Shield(false);

        //jump
        gameplayActions.jump.performed += ctx => playerLocomotion.Jump();
    }

    private void Start()
    {
        
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
