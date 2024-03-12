using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLook : MonoBehaviour
{
    [SerializeField] private GameObject hitObject;
    [SerializeField] private HoverObject currentHoverObject;
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo)) {
            Debug.Log(rayOrigin);
            if (hitInfo.collider != null) {
                hitObject = hitInfo.collider.gameObject;
                if (hitObject.GetComponent<HoverObject>() != null)
                {
                    if (hitObject.GetComponent<HoverObject>() != currentHoverObject){
                        if(currentHoverObject!=null){
                            currentHoverObject.Unhover();
                        }
                        currentHoverObject = hitObject.GetComponent<HoverObject>();
                        currentHoverObject.Hover();
                    }
                }
                else
                {
                    if(currentHoverObject != null) {
                        currentHoverObject.Unhover();
                        currentHoverObject = null;
                    }  
                }
            }
            else 
            {
                if(currentHoverObject != null) {
                    currentHoverObject.Unhover();
                    currentHoverObject = null;
                }
            }
        }
        else{
                if(currentHoverObject != null) {
                    currentHoverObject.Unhover();
                    currentHoverObject = null;
                }
        }
    }
}