using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    //name
    //info
    public string Objectinfo;
    public string ObjectName;
        
    public GameObject prefab;
    void Start() { 
        Unhover();
        prefab.SetActive(true);//ensures that objects are separate from terrain collider 
    }
    public void Hover() {
        //Debug.Log("Hovering!");
        if(GetComponent<Outline>() != null){
            GetComponent<Outline>().enabled = true;
        }
    }

    public void Unhover()
    {
        //Debug.Log("Not hovering!");
        if(GetComponent<Outline>() != null){
            GetComponent<Outline>().enabled = false;
        }
    }

    //Sean's changes
    //select option to display text/change highlight color
    /*public void Selected()
    {
        Debug.Log("Selected");
        if (Input.GetMouseButtonDown(0))
        {
            //change highlight color
            GetComponent<Outline>().enabled = true;
            //display text

        }

    }*/
    //public string returnName()
    //public string returnInfo()
    public string returnName()
    {
        return ObjectName;
    }
    public string returnInfo()
    {
        return Objectinfo;
    }

}