using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private void Start() {
        Cursor.visible = false;
    }

    private void Update()
    {
        //if escape
        //cursor.visible = true
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
        }

        transform.position = Input.mousePosition;
    }
}
