using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelect : MonoBehaviour
{
    private Outline outlineComp;

    private void Start()
    {
        outlineComp = GetComponent<Outline>();    
    }

    private void OnMouseEnter()
    {
        outlineComp.enabled = true; // Enables the outline when the mouse is over the object
    }

    private void OnMouseExit()
    {
        outlineComp.enabled = false; // Disables the outline when the mouse is not over the object
    }
}
