using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class LightingManager : MonoBehaviour
{
    [SerializeField] EndpointLightingData timeData;
    [SerializeField] TransitionData[] transitions;
    Material skyboxMat;
    [SerializeField] Light sun;
    [SerializeField] float lerpValue = 0; //must be 0-1
    [SerializeField] bool usingGrad = true;
    [SerializeField] bool autoLerp = true;
    [SerializeField] float transitionDuration = 300f; // 5 minutes
    int currentTransitionIndex = 0; // Track current transition index
    float transitionStartTime; // Track the start of the current transition

    //for global volume adjustments
    [SerializeField] VolumeProfile profile;
    private Bloom bloom;
    private Vignette vignette;
    private ColorAdjustments ca;
    private ShadowsMidtonesHighlights smh;

    //tree materials
    [SerializeField] Material tallTrunkMat;
    [SerializeField] Material tallBranchMat;
    [SerializeField] Material shortTrunkMat;
    [SerializeField] Material shortBranchMat;

    //[SerializeField] Volume dawnProfile;
    //[SerializeField] Volume dayProfile;
    //[SerializeField] Volume eveningProfile;
    //[SerializeField] Volume nightProfile;

    [SerializeField] Volume[] profiles = new Volume[4];

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
            if(autoLerp)
                lerpValue = Mathf.Clamp01((Time.time - transitionStartTime) / transitionDuration);

            SetSkyColors();
            SetDirectionalLight();
            SetFog();
            //SetGlobalVolume();
            WeighVolumes();
            SetTrees();

            if (lerpValue >= 1.0f)
            {
                currentTransitionIndex = (currentTransitionIndex + 1) % transitions.Length;
                transitionStartTime = Time.time;
            }
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
            skyboxMat.SetColor("_SkyGradientBottom", currentTransition.skyBoxIntensity.Evaluate(lerpValue));
            skyboxMat.SetColor("_SkyGradientTop", currentTransition.skyTopColor.Evaluate(lerpValue));
            skyboxMat.SetColor("_SkyGradientBottom", currentTransition.skyBottomColor.Evaluate(lerpValue));
            skyboxMat.SetFloat("_SkyGradientExponent", (currentTransition.skyGradExponent.Evaluate(lerpValue).r * 5));//needs to be normalized (Color.r returns float between 0-1)
        }
    }

    void SetDirectionalLight()
    {
        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];
            sun.color = currentTransition.emissionColor.Evaluate(lerpValue);
            sun.intensity = currentTransition.emissionIntensity.Evaluate(lerpValue).r * 10; //needs to be normalized
            sun.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(currentTransition.lightRotationX[0], currentTransition.lightRotationX[1], lerpValue), 90f, 0f));
        }
    }

    void SetFog()
    {
        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];
            Color varColor = currentTransition.fogColor.Evaluate(lerpValue);
            RenderSettings.fogColor = currentTransition.fogColor.Evaluate(lerpValue);
            RenderSettings.fogDensity = currentTransition.fogDensity.Evaluate(lerpValue).r * 5; //needs normalizing
            RenderSettings.ambientIntensity = currentTransition.envLightingIntensityMult.Evaluate(lerpValue).r * 8;
            // Debug.Log("Ambient intensity: " + RenderSettings.ambientIntensity);
        }
    }

    void SetIdleColors()
    {
        skyboxMat.SetColor("_SkyGradientTop", timeData.skyTopColor);
        skyboxMat.SetColor("_SkyGradientBottom", timeData.skyBottomColor);
        sun.color = timeData.sunColor;
    }

    void WeighVolumes()
    {
        if (transitions.Length > 0)
        {
            Volume currentVolume = profiles[currentTransitionIndex];
            Volume nextVolume = profiles[(currentTransitionIndex + 1) % transitions.Length];

            currentVolume.weight = 1 - lerpValue;
            nextVolume.weight = lerpValue;
        }
    }
    void SetGlobalVolume()
    {
        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];
            Color varColor; //temp variable

            //colors are 0-255
            //our variables go from min-max
            //translating color to float -> (color.r)/255*[difference between min and max]+min

            //bloom
            if (profile.TryGet<Bloom>(out bloom))
            {
                bloom.threshold.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.bloomThreshold.Evaluate(lerpValue).r /255 * (10-0)));//needs normalizing
                bloom.intensity.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.bloomIntensity.Evaluate(lerpValue).r / 255 * 0.6f+.1f));//needs normalizing
                bloom.scatter.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.bloomScatter.Evaluate(lerpValue).r / 255));//needs normalizing
                varColor = currentTransition.bloomTint.Evaluate(lerpValue);
                bloom.tint.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));
            }

            //vignette
            if (profile.TryGet<Vignette>(out vignette))
            {
                varColor = currentTransition.vignetteColor.Evaluate(lerpValue);
                vignette.color.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));
                vignette.intensity.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.vignetteIntensity.Evaluate(lerpValue).r / 255));//needs normalizing
                vignette.smoothness.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.vignetteSmoothness.Evaluate(lerpValue).r / 255));//needs normalizing
            }

            //color adjustments
            if (profile.TryGet<ColorAdjustments>(out ca))
            {
                ca.postExposure.SetValue(new UnityEngine.Rendering.FloatParameter((currentTransition.adjustPostExposure.Evaluate(lerpValue).r / 255 * (0.29f+0.17f) -0.17f)));//needs normalizing
                ca.contrast.SetValue(new UnityEngine.Rendering.FloatParameter((currentTransition.adjustContrast.Evaluate(lerpValue).r / 255 *(200)) -100));//needs normalizing
                varColor = currentTransition.adjustColorFilter.Evaluate(lerpValue);
                ca.colorFilter.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));
                ca.hueShift.SetValue(new UnityEngine.Rendering.FloatParameter((currentTransition.adjustHueShift.Evaluate(lerpValue).r / 255 *360) - 180));//needs normalizing
                ca.saturation.SetValue(new UnityEngine.Rendering.FloatParameter((currentTransition.adjustSaturation.Evaluate(lerpValue).r / 255 *200)-100));//needs normalizing
            }

            //smh
            if (profile.TryGet<ShadowsMidtonesHighlights>(out smh))
            {
                varColor = currentTransition.smhHighlights.Evaluate(lerpValue);
                smh.highlights.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));
                varColor = currentTransition.smhShadows.Evaluate(lerpValue);
                smh.shadows.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));
                varColor = currentTransition.smhMidtones.Evaluate(lerpValue);
                smh.midtones.SetValue(new UnityEngine.Rendering.Vector4Parameter(new Vector4(varColor.r, varColor.g, varColor.b, 1)));

                smh.highlightsStart.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.smhHighlightStart.Evaluate(lerpValue).r / 255 * 0.68f )); //needs normalizing
                smh.highlightsEnd.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.smhHighlightEnd.Evaluate(lerpValue).r / 255)); //needs normalizing
                smh.shadowsStart.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.smhShadowStart.Evaluate(lerpValue).r / 255)); //needs normalizing
                smh.shadowsEnd.SetValue(new UnityEngine.Rendering.FloatParameter(currentTransition.smhShadowEnd.Evaluate(lerpValue).r / 255 *0.7f)); //needs normalizing
            }

        }
    }

    void SetTrees() 
    {
        if (transitions.Length > 0)
        {
            TransitionData currentTransition = transitions[currentTransitionIndex];
            //tall trees
            tallTrunkMat.color = currentTransition.tallTrunkColor.Evaluate(lerpValue);
            tallBranchMat.SetColor("_branchtint", currentTransition.tallTrunkColor.Evaluate(lerpValue));
            tallBranchMat.SetColor("_leafTint", currentTransition.tallLeafColor.Evaluate(lerpValue));

            //short trees
            shortTrunkMat.color = currentTransition.shortTrunkColor.Evaluate(lerpValue);
            shortBranchMat.SetColor("_branchtint", currentTransition.shortTrunkColor.Evaluate(lerpValue));
            shortBranchMat.SetColor("_leafTint", currentTransition.shortLeafColor.Evaluate(lerpValue));
        }
    }
}
