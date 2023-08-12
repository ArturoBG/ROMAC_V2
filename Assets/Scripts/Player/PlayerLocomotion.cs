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

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveCharacter(Vector2 input)
    {
        //Debug.Log("Input {"+input.x + "}. {"+ input.y+"}");
        Vector3 moveDirectionAnimation = Vector3.zero;
        moveDirectionAnimation.x = input.x;
        moveDirectionAnimation.z = input.y;

        characterController.Move(transform.TransformDirection(moveDirectionAnimation) * defaultSpeed * Time.deltaTime);
    }

}
