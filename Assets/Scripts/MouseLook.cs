using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;

    public Transform playerBody;

    float xRotation = 0f; // The rotation of the camera along the x-axis (up and down)

    bool locked = false; // The camera rotation lock
    
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // mouseX is the horizontal movement of the mouse
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // mouseY is the vertical movement of the mouse

            xRotation -= mouseY; // invert the mouseY to make the camera move in the correct direction
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents the player from looking behind them

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotates the camera up and down
            playerBody.Rotate(Vector3.up * mouseX); // Rotates the player left and right
        }
    }

    public bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }
}
