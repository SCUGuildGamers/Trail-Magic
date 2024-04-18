using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidHandler : MonoBehaviour
{
    polaroidCam = GameObject.FindGameObjectWithTag("PolaroidCamera");
    
    private void Update() {
        
        if(/*Player is in specific Collider*/){
            //Display UI element that tells the player to press E

            if (Input.GetKeyDown(KeyCode.E)) {
                polaroidCam.SetActive(true);
            }
        }
        else {
            polaroidCam.SetActive(false);
        }
    }
}
