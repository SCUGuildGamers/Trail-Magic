using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObjects/EndpointLightingData", order = 1)]
public class EndpointLightingData : ScriptableObject
{
    //skybox data
    public float skyBoxIntensity;
    public Color skyTopColor;
    public Color skyBottomColor;
    public float skyGradExponent;
    public Color sunColor;

    //fog settings
    public Color fogColor;
    public float fogDensity;
    public float envLightingIntensityMult;

    //directional light data
    public Color emissionColor;
    public float emissionIntensity;

    //post-processing data
    //bloom
    public float bloomThreshhold;
    public float bloomIntensity;
    public float bloomScatter;
    public Color bloomTint;

    //vignette
    public Color vignetteColor;
    public float vignetteIntensity;
    public float vignetteSmoothness;

    //color adjustments
    public float adjustPostExposure;
    public float adjustContrast;
    public Color adjustColorFilter;
    public float adjustHueShift;
    public float adjustSaturation;

    //shadows midtones highlights
    public Color smhShadows;
    public Color smhMidtones;
    public Color smhHighlights;

    public float smhShadowStart;
    public float smhShadowEnd;

    public float smhHighlightStart;
    public float smhHighlightEnd;


    //tonemapping
    //(always neutral)

    //other light data? (maybe lights in the cabin)
    //weather (clouds, stars, etc.)
    //terrain data

}
