using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HoverObject : MonoBehaviour
{
    //name
    //info
    public string Objectinfo;
    public string ObjectName;

    [SerializeField] bool isVolcano = false;
    [SerializeField] bool isFlower = false;
    [SerializeField] List<VisualEffect> smoke;
    [SerializeField] List<Gradient> smokeGradients;
        
    public GameObject prefab;

    private void OnAwake()
    {
        if (isFlower)
        {
            prefab.SetActive(false);
        }
    }
    void Start() {
        Unhover();
    }
    public void Hover() {
        //Debug.Log("Hovering!");
        if (isVolcano)
        {
            for (int i = 0; i < smoke.Count; i++)
            {
                smoke[i].SetGradient("GradientColor", smokeGradients[1]);//hovering colored gradient
            }
        }
        else
        {
            if (GetComponent<Outline>() != null)
            {
                GetComponent<Outline>().enabled = true;
            }
        }
    }

    public void Unhover()
    {
        if (isVolcano)
        {
            for (int i = 0; i < smoke.Count; i++)
            {
                smoke[i].SetGradient("GradientColor", smokeGradients[0]);//default color
            }
        }
        else
        {
            //Debug.Log("Not hovering!");
            if (GetComponent<Outline>() != null)
            {
                GetComponent<Outline>().enabled = false;
            }
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