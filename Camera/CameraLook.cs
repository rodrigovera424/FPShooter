using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] 
    public float mouseSensitivity = 1000f;

    public Transform playerBody;

    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        xRotation = 0;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*mouseSensitivity * Time.deltaTime;
       
        xRotation -= MouseY;

        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        playerBody.Rotate(Vector3.up * MouseX);  
    }
}  