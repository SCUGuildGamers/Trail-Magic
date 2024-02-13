using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    MouseLook mouseLook;

    bool visible = false;
    
    private void Start() {
        // Cursor.visible = visible;

        mouseLook = FindAnyObjectByType<MouseLook>();
    }

    private void Update()
    {
        //if escape
        //cursor.visible = true
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            visible = !visible;
            // Cursor.visible = visible;
            mouseLook.Locked = visible;
        }

        transform.position = Input.mousePosition;
    }
}
