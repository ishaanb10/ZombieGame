using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity=100f;
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // making sure mouse doesn't leave game window
        Cursor.lockState = CursorLockMode.Locked; //CursorLockMode is enum - 0=none, 1=locked, 2=confined;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        xRotation -= mouseY;
        //using clamp to restrict rotation - avoid infinite rotation (90deg up 90 deg down in x axis)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //to rotate player in all directions
        playerBody.Rotate(Vector3.up * mouseX);

       

    }
}
