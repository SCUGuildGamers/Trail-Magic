using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidHandler : MonoBehaviour
{   [SerializeField] string polaroidTag;
    [SerializeField] GameObject polaroidCam;

    [SerializeField] private GameObject floatingTextPrefab;
    private GameObject uiElement;

    private bool polaroidState;
    
    void Start() {
        polaroidState = false;
        uiElement = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        PolaroidStateHandler();
    }
    
    void Update() {
        PolaroidStateHandler();
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == polaroidTag) {
            Debug.Log("Triggered with: " + collider.gameObject.name);
            polaroidState = true; 
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.tag == polaroidTag) {
            Debug.Log("Triggered with: " + collider.gameObject.name);
            polaroidState = false;
        }
    }

    void PolaroidStateHandler () {
        if (polaroidState == true) {
            uiElement.SetActive(true);
            if (Input.GetKey(KeyCode.Space)) {
                Debug.Log("space");
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
