using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    MouseLook mouseLook;

    bool visible = false;
    
    private void Start() {
        Cursor.visible = false;

        mouseLook = FindAnyObjectByType<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            visible = !visible;
            Cursor.visible = false; // cursor never visible
            mouseLook.Locked = visible;
        }

        transform.position = Input.mousePosition;
    }
}
