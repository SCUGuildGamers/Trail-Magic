using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    MouseLook mouseLook;

    // bool visible = false;
    bool locked = true; // cursor locked to reticle
    
    private void Start() 
    {
        Cursor.visible = false;

        mouseLook = FindAnyObjectByType<MouseLook>();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     visible = !visible;
        //     mouseLook.Locked = visible;
        // }

        if (locked) 
        {
            Cursor.visible = false; // cursor never visible
            mouseLook.Locked = false;
            //transform.position = Input.mousePosition;
        }
        else 
        {
            Cursor.visible = true; // cursor always visible
            mouseLook.Locked = true;
        }
    }

    public bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }
}
