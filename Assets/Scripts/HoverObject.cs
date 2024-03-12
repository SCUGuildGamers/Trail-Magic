using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    void Start(){
        Unhover();
    }
    public void Hover() {
        Debug.Log("Hovering!");
        if(GetComponent<Outline>() != null){
            GetComponent<Outline>().enabled = true;
        }
    }

    public void Unhover()
    {
        Debug.Log("Not hovering!");
        if(GetComponent<Outline>() != null)
            GetComponent<Outline>().enabled = false;
    }
}