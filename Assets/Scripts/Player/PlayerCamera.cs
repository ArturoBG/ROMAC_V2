using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;

    [SerializeField]
    private float xRotation;

    [SerializeField] 
    private float ySensitivity = 1f;
    [SerializeField] 
    private float xSensitivity = 1f;

    [SerializeField]
    private float minX = -60f;

    [SerializeField]
    private float maxX = 60f;

    public void ProcessLook(Vector2 input)
    {
        //Debug.Log("Camera {" + input.x + "}. {" + input.y + "}");
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        MainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        
    }
}
