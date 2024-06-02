using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OutlineLook : MonoBehaviour
{
    private GameObject hitObject;
    private HoverObject currentHoverObject;
    private bool selected = false;
    //text script object (sean stuff)
    [SerializeField] private GameObject uiCanvas;
    // tmp name public
    [SerializeField] private TextMeshProUGUI NameText;
    //tmp body
    [SerializeField] private TextMeshProUGUI BodyText;
    // Update is called once per frame
    [SerializeField] private GameObject inGameMenu;

    private void Start()
    {
        uiCanvas.SetActive(false);
        selected = false;
    }

    void Update()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        float maxDistance = Mathf.Infinity;

        if (Physics.Raycast(rayOrigin, out hitInfo, maxDistance)) {
            if (hitInfo.collider != null) {
                //Debug.Log("hit " + hitInfo.collider.gameObject.name);
                hitObject = hitInfo.collider.gameObject;
                if (hitObject.GetComponent<HoverObject>() != null)
                {
                    if (hitObject.GetComponent<HoverObject>() != currentHoverObject){
                        if(currentHoverObject!=null){
                            currentHoverObject.Unhover();
                            uiCanvas.SetActive(false);
                            selected = false;
                        }
                        currentHoverObject = hitObject.GetComponent<HoverObject>();
                        currentHoverObject.Hover();
                    }
                }
                else
                {
                    if(currentHoverObject != null) {
                        currentHoverObject.Unhover();
                        uiCanvas.SetActive(false);
                        currentHoverObject = null;
                        selected = false;
                    }  
                }
            }
            else 
            {
                if(currentHoverObject != null) {
                    currentHoverObject.Unhover();
                    uiCanvas.SetActive(false);
                    currentHoverObject = null;
                    selected = false;
                }
            }
        }
        else{
                if(currentHoverObject != null) {
                    currentHoverObject.Unhover();
                    uiCanvas.SetActive(false);
                    currentHoverObject = null;
                    selected = false;
                }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!inGameMenu.activeSelf)
            {
                Selected();
            }
        }
    }
    //make a select function here
    //the function will be triggered by mouse click
    //check to see if we're hovering over a hoverable object
    //if(currentHoverObject != null)
    //enable canvas
    //fill canvas with info grabbed from hover object
    
    void Selected()
    {
        if (currentHoverObject != null)
        {

            Debug.Log("selecting");
            //enable canvas
            selected = !selected;
            uiCanvas.SetActive(selected);
            //set the text in both tmp text to the strings that you can call from the hoverobject
            //fill canvas with info grabbed from hover object
            NameText.SetText(currentHoverObject.ObjectName);
            BodyText.SetText(currentHoverObject.Objectinfo);
        }
    }
}