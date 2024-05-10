using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidHandler : MonoBehaviour
{   [SerializeField] string polaroidTag;
    [SerializeField] GameObject polaroidCam;
    [SerializeField] GameObject eightiesPolaroid;
    [SerializeField] GameObject ninetiesPolaroid;
    [SerializeField] GameObject bwPolaroid;

    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject uiElement;
    private bool polaroidState;
    
    void Start() {
        polaroidState = false;
        eightiesPolaroid.SetActive(false);
        ninetiesPolaroid.SetActive(false);
        bwPolaroid.SetActive(false);
        uiElement = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        PolaroidStateHandler();
    }
    
    void Update() {
        PolaroidStateHandler();
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == polaroidTag) {
            Debug.Log("Entering!");
            polaroidState = true; 
            string era = collider.gameObject.GetComponent<PolaroidArea>().getTimeframe();
            if(era == "80s") {
                eightiesPolaroid.SetActive(true);
            }
            else if (era == "90s") {
                ninetiesPolaroid.SetActive(true);
            }
            else if (era == "bw") {
                bwPolaroid.SetActive(true);
            }  
            /*else {
                eightiesPolaroid.SetActive(false);
                ninetiesPolaroid.SetActive(false);
                bwPolaroid.SetActive(false);
            }*/
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.tag == polaroidTag) {
            Debug.Log("Exiting!");
            polaroidState = false;
            eightiesPolaroid.SetActive(false);
            ninetiesPolaroid.SetActive(false);
            bwPolaroid.SetActive(false);
        }
    }

    void PolaroidStateHandler () {
        if (polaroidState == true) {
            uiElement.SetActive(true);
            if (Input.GetKey("space")) {
                Debug.Log("Space was pressed");
                polaroidCam.SetActive(true); 
                uiElement.SetActive(false);
            }
        }
        else {
            polaroidCam.SetActive(false);
            uiElement.SetActive(false);
        }    
    }
}
