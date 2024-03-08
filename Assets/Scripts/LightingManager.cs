using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] LightingData startData;
    [SerializeField] LightingData endData;
    Material skyboxMat;
    [SerializeField] float lerpValue = 0; //must be 0-1
    // Start is called before the first frame update
    void Start()
    {
        skyboxMat = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        setSkyColors();
    }

    void setSkyColors()
    {
        //skyboxMat.SetColor("_SkyGradientTop", nightData.skyTopColor);
        //skyboxMat.SetColor("_SkyGradientBottom", nightData.skyBottomColor);
        //skyboxMat.SetColor("_SkyGradientTop", startData.skyTopGrad.Evaluate(lerpValue));
        //skyboxMat.SetColor("_SkyGradientBottom", startData.skyBottomGrad.Evaluate(lerpValue));
        skyboxMat.SetColor("_SkyGradientTop", Color.Lerp(startData.skyTopColor, endData.skyTopColor, lerpValue));
        skyboxMat.SetColor("_SkyGradientBottom", Color.Lerp(startData.skyBottomColor, endData.skyBottomColor, lerpValue));
    }
}
