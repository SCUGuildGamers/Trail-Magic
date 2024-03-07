using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    private GameObject currentHoverObject;
    public void Hover() {
        currentHoverObject.GetComponent<Outline>().enabled = true;
    }

    public void Unhover()
    {
        currentHoverObject.GetComponent<Outline>().enabled = false;
    }
}