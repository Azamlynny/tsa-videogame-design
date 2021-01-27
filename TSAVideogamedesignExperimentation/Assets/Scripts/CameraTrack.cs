using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    public float mouseSensitivity = 500f;   
    public GameObject player;
    
    float xRotation = 0f;
    float yRotation = 0f;
    float zRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {        
        transform.position = player.transform.position;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // inverted control so negative
        xRotation = Mathf.Clamp(xRotation, -89f, 89f); // Prevent the player from looking over themselves
        
        yRotation += mouseX; 

        transform.localRotation = player.transform.rotation * Quaternion.Euler(xRotation, yRotation, zRotation);

    }
}
