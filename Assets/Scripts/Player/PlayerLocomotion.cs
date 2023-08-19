using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    private Vector3 playerVelocity;

    [SerializeField]
    private float defaultSpeed = 5f;

    [SerializeField]
    private float sprintSpeeed = 10f;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private bool isGrounded = false;

    [SerializeField]
    private float jumpingHeight = 5f;

    private CharacterController characterController;

    [SerializeField]
    private Animator playerAnimator;

    private Vector2 currentAnimationBlend;
    private Vector2 animationVelocity;
    [SerializeField]
    private float animationSmoothFactor = 0.1f;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    public void MoveCharacter(Vector2 input)
    {
       // Debug.Log("Input {"+input.x + "}. {"+ input.y+"}");
        Vector3 moveDirectionAnimation = Vector3.zero;
        Vector2 animationBlending = Vector2.zero;
        moveDirectionAnimation.x = input.x;
        animationBlending.x = input.x;
        moveDirectionAnimation.z = input.y;
        animationBlending.y = input.y;
        
        //Movement of character controller
        characterController.Move(transform.TransformDirection(moveDirectionAnimation) * defaultSpeed * Time.deltaTime);

        //animation movement
        
        currentAnimationBlend = Vector2.SmoothDamp(currentAnimationBlend, animationBlending, ref animationVelocity, animationSmoothFactor);
        //Debug.Log("Current animation blend x:"+currentAnimationBlend.x +"  y:" +currentAnimationBlend.y);

        playerAnimator.SetFloat("MoveZ", currentAnimationBlend.y);
        playerAnimator.SetFloat("MoveX", currentAnimationBlend.x);
    }

}
