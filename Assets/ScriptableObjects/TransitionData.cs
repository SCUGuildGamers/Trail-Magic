using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TransitionData", order = 1)]

public class TransitionData : ScriptableObject
{

    //skybox data
    public Gradient skyBoxIntensity;
    public Gradient skyTopColor;
    public Gradient skyBottomColor;
    public Gradient skyGradExponent;

    public Gradient sunColor;

    //fog settings
    public Gradient fogColor;
    public Gradient fogDensity;
    public Gradient envLightingIntensityMult;


    //directional light data
    public Gradient emissionColor;
    public Gradient emissionIntensity;

    //public Gradient lightRotationX;
    public float[] lightRotationX = new float[2];

    public Gradient volumeWeight; // needs to be inputted
    public VolumeProfile profile; // needs to be inputted

    //bloom
    public Gradient bloomThreshold;
    public Gradient bloomIntensity;
    public Gradient bloomScatter;
    public Gradient bloomTint;


    //vignette
    public Gradient vignetteColor;
    public Gradient vignetteIntensity;
    public Gradient vignetteSmoothness;

    //color adjustments
    public Gradient adjustPostExposure;
    public Gradient adjustContrast;
    public Gradient adjustColorFilter; // needs to be fully inputted
    public Gradient adjustHueShift;
    public Gradient adjustSaturation;

    //shadows midtones highlights
    public Gradient smhShadows;
    public Gradient smhMidtones;
    public Gradient smhHighlights;

    public Gradient smhShadowStart;
    public Gradient smhShadowEnd;

    public Gradient smhHighlightStart;
    public Gradient smhHighlightEnd; // needs to be inputted

    //trees
    public Gradient tallTrunkColor;
    public Gradient tallLeafColor;
    public Gradient shortTrunkColor;
    public Gradient shortLeafColor;

    //cabin
    public Gradient woodColor;
}
