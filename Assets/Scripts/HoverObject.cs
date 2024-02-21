using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    [SerializeField] Color outlineColor;
    private void Start()
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject interactable in interactables)
        {
            if (interactable.GetComponent<Outline>() == null) 
            {
                interactable.AddComponent<Outline>();
                interactable.GetComponent<Outline>().enabled = false;
                interactable.GetComponent<Outline>().OutlineColor = outlineColor;
                interactable.GetComponent<Outline>().OutlineWidth = 5f;
            }
            else{
                interactable.GetComponent<Outline>().enabled = true;
            }
            if (interactable.GetComponent<OutlineSelect>() == null) 
            {
                interactable.GetComponent<OutlineSelect>();
            }
            if (interactable.GetComponent<BoxCollider>() == null)
            {
                interactable.GetComponent<BoxCollider>();
            }
        }
    }
}
