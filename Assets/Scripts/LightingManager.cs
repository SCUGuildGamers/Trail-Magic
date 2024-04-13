using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] EndpointLightingData timeData;
    [SerializeField] TransitionData[] transitions;
    Material skyboxMat;
    [SerializeField] Light sun;
    [SerializeField] float lerpValue = 0; //must be 0-1
    [SerializeField] bool usingGrad = true;
    [SerializeField] float transitionDuration = 300f; // 5 minutes
    int currentTransitionIndex = 0; // Track current transition index
    float transitionStartTime; // Track the start of the current transition
 
    // Start is called before the first frame update
    void Start()
    {
        skyboxMat = RenderSettings.skybox;
        transitionStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (usingGrad)
        {
            lerpValue = Mathf.Clamp01((Time.time - transitionStartTime) / transitionDuration);

            SetSkyColors();
            SetDirectionalLight();
        }
        else
        {
            SetIdleColors();
        }
    }

    void SetSkyColors()
    {
        //skyboxMat.SetColor("_SkyGradientTop", nightData.skyTopColor);
        //skyboxMat.SetColor("_SkyGradientBottom", nightData.skyBottomColor);
        //skyboxMat.SetColor("_SkyGradientTop", startData.skyTopGrad.Evaluate(lerpValue));
        //skyboxMat.SetColor("_SkyGradientBottom", startData.skyBottomGrad.Evaluate(lerpValue));
        //skyboxMat.SetColor("_SkyGradientTop", Color.Lerp(startData.skyTopColor, endData.skyTopColor, lerpValue));
        //skyboxMat.SetColor("_SkyGradientBottom", Color.Lerp(startData.skyBottomColor, endData.skyBottomColor, lerpValue));

        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];

            // Apply sky colors from the current transition data
            skyboxMat.SetColor("_SkyGradientTop", currentTransition.skyTopColor.Evaluate(lerpValue));
            skyboxMat.SetColor("_SkyGradientBottom", currentTransition.skyBottomColor.Evaluate(lerpValue));

            if (lerpValue >= 1.0f)
            {
                currentTransitionIndex = (currentTransitionIndex + 1) % transitions.Length;
                transitionStartTime = Time.time;
            }
        }
    }

    void SetDirectionalLight()
    {
        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];
            sun.color = currentTransition.sunColor.Evaluate(lerpValue);
        }
    }

    void SetIdleColors()
    {
        skyboxMat.SetColor("_SkyGradientTop", timeData.skyTopColor);
        skyboxMat.SetColor("_SkyGradientBottom", timeData.skyBottomColor);
        sun.color = timeData.sunColor;
    }
}
