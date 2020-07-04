using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public float cameraSens = 200f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    float zRotation = 0f;
    float rotationSpeed = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseXAxis = Input.GetAxis("Mouse X") * cameraSens * Time.deltaTime;
        float MouseYAxis = Input.GetAxis("Mouse Y") * cameraSens * Time.deltaTime;
        xRotation -= MouseYAxis;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * MouseXAxis);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        zRotation = Mathf.Clamp(zRotation, -5f, 5f);

        if (Input.GetKey(KeyCode.D)) {
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation -= rotationSpeed);

        }
        else
        {
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation += rotationSpeed);
        }
        


        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation += rotationSpeed);
            
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation -= rotationSpeed);
            
        }
        
    }
}