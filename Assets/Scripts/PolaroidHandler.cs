using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidHandler : MonoBehaviour
{   [SerializeField] string polaroidTag;
    [SerializeField] GameObject polaroidCam;
    [SerializeField] GameObject eightiesPolaroid;
    [SerializeField] GameObject ninetiesPolaroid;
    [SerializeField] GameObject bwPolaroid;
    [SerializeField] private GameObject explanation;
    private bool polaroidState;
    private bool polaroidOn;
    private bool canTogglePolaroid = true; // flag to prevent rapid toggling
    
    void Start() 
    {
        polaroidState = false;
        polaroidOn = false;
        eightiesPolaroid.SetActive(false);
        ninetiesPolaroid.SetActive(false);
        bwPolaroid.SetActive(false);
        PolaroidStateHandler();
    }
    
    void Update() 
    {
        PolaroidStateHandler();
    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag(polaroidTag)) 
        {
            polaroidState = true; 
            string era = collider.gameObject.GetComponent<PolaroidArea>().getTimeframe();
            if(era == "80s") 
            {
                eightiesPolaroid.SetActive(true);
            }
            else if (era == "90s") 
            {
                ninetiesPolaroid.SetActive(true);
            }
            else if (era == "bw") 
            {
                bwPolaroid.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collider) 
    {
        if(collider.gameObject.CompareTag(polaroidTag)) 
        {
            polaroidState = false;
            eightiesPolaroid.SetActive(false);
            ninetiesPolaroid.SetActive(false);
            bwPolaroid.SetActive(false);
        }
    }

    void PolaroidStateHandler () 
    {
        if (polaroidState == true) 
        {
            if(!polaroidOn) 
            {
                explanation.SetActive(true);
            } else 
            {
                explanation.SetActive(false);
            }
            
            if (Input.GetKey(KeyCode.Space) && canTogglePolaroid) 
            {
                StartCoroutine(TogglePolaroidWithDelay());
            }
        }
        else 
        {
            polaroidOn = false;
            polaroidCam.SetActive(false);
            explanation.SetActive(false);
        }    
    }

    IEnumerator TogglePolaroidWithDelay()
    {
        canTogglePolaroid = false;
        polaroidOn = !polaroidOn;
        polaroidCam.SetActive(polaroidOn);
        yield return new WaitForSeconds(0.5f);
        canTogglePolaroid = true;
    }
}
