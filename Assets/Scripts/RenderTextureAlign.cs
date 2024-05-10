using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureAlignScript : MonoBehaviour
{
    [SerializeField] Camera thisCam;
    [SerializeField] Camera mainCam;
    [SerializeField] Material thisCamMaterial;


    // Start is called before the first frame update
    void Start()
    {
        //thisCam = GetComponent<Camera>();
        mainCam = Camera.main;
        if (thisCam.targetTexture != null) {
            thisCam.targetTexture.Release();
        }

        if (mainCam.targetTexture != null) {
            mainCam.targetTexture.Release();
        }

        thisCam.targetTexture.width = Screen.width;
        thisCam.targetTexture.height = Screen.height;

        thisCamMaterial.mainTexture = thisCam.targetTexture;
    }
}
