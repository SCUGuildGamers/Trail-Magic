using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    
    private GameObject prefab;
    void Start(){
        prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        Unhover();
    }
    public void Hover() {
        Debug.Log("Hovering!");
        if(GetComponent<Outline>() != null){
            GetComponent<Outline>().enabled = true;
            prefab.SetActive(true);
        }
    }

    public void Unhover()
    {
        Debug.Log("Not hovering!");
        if(GetComponent<Outline>() != null){
            GetComponent<Outline>().enabled = false;
            prefab.SetActive(false);
        }
    }

}