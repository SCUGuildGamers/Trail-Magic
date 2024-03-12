using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] EndpointLightingData timeData;
    [SerializeField] TransitionData transition;
    Material skyboxMat;
    [SerializeField] Light sun;
    [SerializeField] float lerpValue = 0; //must be 0-1
    [SerializeField] bool usingGrad = true;
    // Start is called before the first frame update
    void Start()
    {
        skyboxMat = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingGrad)
        {
            setSkyColors();
            SetDirectionalLight();
        }
        else
        {
            setIdleColors();
        }
    }

    void setSkyColors()
    {
        //skyboxMat.SetColor("_SkyGradientTop", nightData.skyTopColor);
        //skyboxMat.SetColor("_SkyGradientBottom", nightData.skyBottomColor);
        //skyboxMat.SetColor("_SkyGradientTop", startData.skyTopGrad.Evaluate(lerpValue));
        //skyboxMat.SetColor("_SkyGradientBottom", startData.skyBottomGrad.Evaluate(lerpValue));
        //skyboxMat.SetColor("_SkyGradientTop", Color.Lerp(startData.skyTopColor, endData.skyTopColor, lerpValue));
        //skyboxMat.SetColor("_SkyGradientBottom", Color.Lerp(startData.skyBottomColor, endData.skyBottomColor, lerpValue));

        skyboxMat.SetColor("_SkyGradientTop", transition.skyTopColor.Evaluate(lerpValue));
        skyboxMat.SetColor("_SkyGradientBottom", transition.skyBottomColor.Evaluate(lerpValue));
    }

    void SetDirectionalLight()
    {
        sun.color = transition.sunColor.Evaluate(lerpValue);
    }

    void setIdleColors()
    {
        skyboxMat.SetColor("_SkyGradientTop", timeData.skyTopColor);
        skyboxMat.SetColor("_SkyGradientBottom", timeData.skyBottomColor);
        sun.color = timeData.sunColor;
    }


}
