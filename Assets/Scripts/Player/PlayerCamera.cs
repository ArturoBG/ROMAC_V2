using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Tooltip("PLAYER->ThirdPersonCamera. Virtual Cam que sigue al personaje")]
    [SerializeField] private CinemachineVirtualCamera TPC;

    [Header("FirsPersonCamera")]
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

    [Header("ThirdPersonCamera")]
    public Transform followTarget;
    public float horizontalTurnSpeed = 1f;
    public float verticalTurnSpeed = 1f;

    private void Start()
    {
        
    }

    public void ProcessLook(Vector2 input)
    {
        ThirdPersonCamera(input);
    }

    public void FirstPersonCamera(Vector2 input)
    {
        //Debug.Log("Camera {" + input.x + "}. {" + input.y + "}");
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        TPC.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }

    public void ThirdPersonCamera(Vector2 input)
    {
        var rotInput = new Vector2(input.x, input.y);
        var rot = transform.eulerAngles;
        rot.y += rotInput.x * horizontalTurnSpeed;

        transform.rotation = Quaternion.Euler(rot);

        if (followTarget != null)
        {
            rot = followTarget.localRotation.eulerAngles;
            rot.x -= rotInput.y * verticalTurnSpeed;
            if (rot.x > 180)
            {
                rot.x -= 360;
            }
            rot.x = Mathf.Clamp(rot.x, minX, maxX);
            followTarget.localRotation = Quaternion.Euler(rot);
        }       

    }
}